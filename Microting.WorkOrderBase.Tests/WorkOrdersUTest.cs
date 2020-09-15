/*
The MIT License (MIT)

Copyright (c) 2007 - 2019 Microting A/S

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

namespace Microting.WorkOrderBase.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using eForm.Infrastructure.Constants;
    using Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    [TestFixture]
    public class WorkOrdersUTest : DbTestFixture
    {
        [Test]
        public async Task WorkOrder_Create_DoesCreate()
        {
            // Arrange
            Random rnd = new Random();

            WorkOrder workOrder = new WorkOrder
            {
                CreatedByUserId = rnd.Next(1, 255),
                Description = Guid.NewGuid().ToString(),
                CorrectedAtLatest = DateTime.UtcNow,
                DoneAt = DateTime.UtcNow,
                DoneBySiteId = rnd.Next(1, 255),
                DescriptionOfTaskDone = Guid.NewGuid().ToString()
            };

            // Act
            await workOrder.Create(DbContext);

            // Assert
            WorkOrder dbWorkOrder = DbContext.WorkOrders.AsNoTracking().First();
            List<WorkOrder> workOrders = DbContext.WorkOrders.AsNoTracking().ToList();
            WorkOrderVersion dbWorkOrderVersion = DbContext.WorkOrderVersions.AsNoTracking().First();
            List<WorkOrderVersion> workOrderVersions = DbContext.WorkOrderVersions.AsNoTracking().ToList();

            Assert.NotNull(dbWorkOrder);
            Assert.NotNull(dbWorkOrderVersion);
            Assert.AreEqual(1, workOrders.Count);
            Assert.AreEqual(1, workOrderVersions.Count);

            Assert.AreEqual(workOrder.Id, dbWorkOrder.Id);
            Assert.AreEqual(workOrder.Version, dbWorkOrder.Version);
            Assert.AreEqual(workOrder.WorkflowState, dbWorkOrder.WorkflowState);
            Assert.AreEqual(workOrder.CreatedAt.ToString("HH:mm:ss"), dbWorkOrder.CreatedAt.ToString("HH:mm:ss"));
            Assert.AreEqual(workOrder.CreatedByUserId, dbWorkOrder.CreatedByUserId);
            Assert.AreEqual(workOrder.UpdatedAt.ToString(), dbWorkOrder.UpdatedAt.ToString());
            Assert.AreEqual(workOrder.UpdatedByUserId, dbWorkOrder.UpdatedByUserId);
            Assert.AreEqual(workOrder.Description, dbWorkOrder.Description);
            Assert.AreEqual(workOrder.CorrectedAtLatest.ToString(), dbWorkOrder.CorrectedAtLatest.ToString());
            Assert.AreEqual(workOrder.DoneAt.ToString(), dbWorkOrder.DoneAt.ToString());
            Assert.AreEqual(workOrder.DoneBySiteId, dbWorkOrder.DoneBySiteId);
            Assert.AreEqual(workOrder.DescriptionOfTaskDone, dbWorkOrder.DescriptionOfTaskDone);
        }

        [Test]
        public async Task WorkOrder_Update_DoesUpdate()
        {
            // Arrange
            Random rnd = new Random();

            WorkOrder workOrder = new WorkOrder
            {
                CreatedByUserId = rnd.Next(1, 255),
                Description = Guid.NewGuid().ToString(),
                CorrectedAtLatest = DateTime.UtcNow,
                DoneAt = DateTime.UtcNow,
                DoneBySiteId = rnd.Next(1, 255),
                DescriptionOfTaskDone = Guid.NewGuid().ToString()
            };

            await workOrder.Create(DbContext);

            // Act
            var oldDescription = workOrder.Description;
            var oldDoneBySiteId = workOrder.DoneBySiteId;
            var oldUpdatedAt = workOrder.UpdatedAt.GetValueOrDefault();

            workOrder.Description = Guid.NewGuid().ToString();
            workOrder.DoneBySiteId = rnd.Next(1, 255);

            await workOrder.Update(DbContext);

            // Assert
            WorkOrder dbWorkOrder = DbContext.WorkOrders.AsNoTracking().First();
            List<WorkOrder> workOrders = DbContext.WorkOrders.AsNoTracking().ToList();
            List<WorkOrderVersion> workOrderVersions = DbContext.WorkOrderVersions.AsNoTracking().ToList();

            Assert.NotNull(dbWorkOrder);
            Assert.AreEqual(1, workOrders.Count);
            Assert.AreEqual(2, workOrderVersions.Count);

            Assert.AreEqual(workOrder.Id, dbWorkOrder.Id);
            Assert.AreEqual(workOrder.Version, dbWorkOrder.Version);
            Assert.AreEqual(workOrder.WorkflowState, dbWorkOrder.WorkflowState);
            Assert.AreEqual(workOrder.CreatedAt.ToString(), dbWorkOrder.CreatedAt.ToString());
            Assert.AreEqual(workOrder.CreatedByUserId, dbWorkOrder.CreatedByUserId);
            Assert.AreEqual(workOrder.UpdatedAt.ToString(), dbWorkOrder.UpdatedAt.ToString());
            Assert.AreEqual(workOrder.UpdatedByUserId, dbWorkOrder.UpdatedByUserId);
            Assert.AreEqual(workOrder.Description, dbWorkOrder.Description);
            Assert.AreEqual(workOrder.CorrectedAtLatest.ToString(), dbWorkOrder.CorrectedAtLatest.ToString());
            Assert.AreEqual(workOrder.DoneAt.ToString(), dbWorkOrder.DoneAt.ToString());
            Assert.AreEqual(workOrder.DoneBySiteId, dbWorkOrder.DoneBySiteId);
            Assert.AreEqual(workOrder.DescriptionOfTaskDone, dbWorkOrder.DescriptionOfTaskDone);

            Assert.AreEqual(workOrder.Id, workOrderVersions[0].WorkOrderId);
            Assert.AreEqual(1, workOrderVersions[0].Version);
            Assert.AreEqual(workOrder.WorkflowState, workOrderVersions[0].WorkflowState);
            Assert.AreEqual(workOrder.CreatedAt.ToString(), workOrderVersions[0].CreatedAt.ToString());
            Assert.AreEqual(workOrder.CreatedByUserId, workOrderVersions[0].CreatedByUserId);
            Assert.AreEqual(oldUpdatedAt.ToString(), workOrderVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(workOrder.UpdatedByUserId, workOrderVersions[0].UpdatedByUserId);
            Assert.AreEqual(oldDescription, workOrderVersions[0].Description);
            Assert.AreEqual(workOrder.CorrectedAtLatest.ToString(), workOrderVersions[0].CorrectedAtLatest.ToString());
            Assert.AreEqual(workOrder.DoneAt.ToString(), workOrderVersions[0].DoneAt.ToString());
            Assert.AreEqual(oldDoneBySiteId, workOrderVersions[0].DoneBySiteId);
            Assert.AreEqual(workOrder.DescriptionOfTaskDone, workOrderVersions[0].DescriptionOfTaskDone);

            Assert.AreEqual(workOrder.Id, workOrderVersions[1].WorkOrderId);
            Assert.AreEqual(2, workOrderVersions[1].Version);
            Assert.AreEqual(workOrder.WorkflowState, workOrderVersions[1].WorkflowState);
            Assert.AreEqual(workOrder.CreatedAt.ToString(), workOrderVersions[1].CreatedAt.ToString());
            Assert.AreEqual(workOrder.CreatedByUserId, workOrderVersions[1].CreatedByUserId);
            Assert.AreEqual(workOrder.UpdatedAt.ToString(), workOrderVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(workOrder.UpdatedByUserId, workOrderVersions[1].UpdatedByUserId);
            Assert.AreEqual(workOrder.UpdatedByUserId, workOrderVersions[0].UpdatedByUserId);
            Assert.AreEqual(workOrder.Description, workOrderVersions[1].Description);
            Assert.AreEqual(workOrder.CorrectedAtLatest.ToString(), workOrderVersions[1].CorrectedAtLatest.ToString());
            Assert.AreEqual(workOrder.DoneAt.ToString(), workOrderVersions[1].DoneAt.ToString());
            Assert.AreEqual(workOrder.DoneBySiteId, workOrderVersions[1].DoneBySiteId);
            Assert.AreEqual(workOrder.DescriptionOfTaskDone, workOrderVersions[1].DescriptionOfTaskDone);
        }

        [Test]
        public async Task WorkOrder_Delete_DoesDelete()
        {
            // Arrange
            Random rnd = new Random();

            WorkOrder workOrder = new WorkOrder
            {
                CreatedByUserId = rnd.Next(1, 255),
                Description = Guid.NewGuid().ToString(),
                CorrectedAtLatest = DateTime.UtcNow,
                DoneAt = DateTime.UtcNow,
                DoneBySiteId = rnd.Next(1, 255),
                DescriptionOfTaskDone = Guid.NewGuid().ToString()
            };

            await workOrder.Create(DbContext);

            // Act
            var oldUpdatedAt = workOrder.UpdatedAt.GetValueOrDefault();

            await workOrder.Delete(DbContext);

            // Assert
            WorkOrder dbWorkOrder = DbContext.WorkOrders.AsNoTracking().First();
            List<WorkOrder> workOrders = DbContext.WorkOrders.AsNoTracking().ToList();
            List<WorkOrderVersion> workOrderVersions = DbContext.WorkOrderVersions.AsNoTracking().ToList();

            Assert.NotNull(dbWorkOrder);
            Assert.AreEqual(1, workOrders.Count);
            Assert.AreEqual(2, workOrderVersions.Count);

            Assert.AreEqual(workOrder.Id, dbWorkOrder.Id);
            Assert.AreEqual(workOrder.Version, dbWorkOrder.Version);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbWorkOrder.WorkflowState);
            Assert.AreEqual(workOrder.CreatedAt.ToString(), dbWorkOrder.CreatedAt.ToString());
            Assert.AreEqual(workOrder.CreatedByUserId, dbWorkOrder.CreatedByUserId);
            Assert.AreEqual(workOrder.UpdatedAt.ToString(), dbWorkOrder.UpdatedAt.ToString());
            Assert.AreEqual(workOrder.UpdatedByUserId, dbWorkOrder.UpdatedByUserId);
            Assert.AreEqual(workOrder.Description, dbWorkOrder.Description);
            Assert.AreEqual(workOrder.CorrectedAtLatest.ToString(), dbWorkOrder.CorrectedAtLatest.ToString());
            Assert.AreEqual(workOrder.DoneAt.ToString(), dbWorkOrder.DoneAt.ToString());
            Assert.AreEqual(workOrder.DoneBySiteId, dbWorkOrder.DoneBySiteId);
            Assert.AreEqual(workOrder.DescriptionOfTaskDone, dbWorkOrder.DescriptionOfTaskDone);

            Assert.AreEqual(workOrder.Id, workOrderVersions[0].WorkOrderId);
            Assert.AreEqual(1, workOrderVersions[0].Version);
            Assert.AreEqual(Constants.WorkflowStates.Created, workOrderVersions[0].WorkflowState);
            Assert.AreEqual(workOrder.CreatedAt.ToString(), workOrderVersions[0].CreatedAt.ToString());
            Assert.AreEqual(workOrder.CreatedByUserId, workOrderVersions[0].CreatedByUserId);
            Assert.AreEqual(oldUpdatedAt.ToString(), workOrderVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(workOrder.UpdatedByUserId, workOrderVersions[0].UpdatedByUserId);
            Assert.AreEqual(workOrder.Description, dbWorkOrder.Description);
            Assert.AreEqual(workOrder.CorrectedAtLatest.ToString(), dbWorkOrder.CorrectedAtLatest.ToString());
            Assert.AreEqual(workOrder.DoneAt.ToString(), dbWorkOrder.DoneAt.ToString());
            Assert.AreEqual(workOrder.DoneBySiteId, dbWorkOrder.DoneBySiteId);
            Assert.AreEqual(workOrder.DescriptionOfTaskDone, dbWorkOrder.DescriptionOfTaskDone);

            Assert.AreEqual(workOrder.Id, workOrderVersions[1].WorkOrderId);
            Assert.AreEqual(2, workOrderVersions[1].Version);
            Assert.AreEqual(Constants.WorkflowStates.Removed, workOrderVersions[1].WorkflowState);
            Assert.AreEqual(workOrder.CreatedAt.ToString(), workOrderVersions[1].CreatedAt.ToString());
            Assert.AreEqual(workOrder.CreatedByUserId, workOrderVersions[1].CreatedByUserId);
            Assert.AreEqual(workOrder.UpdatedAt.ToString(), workOrderVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(workOrder.UpdatedByUserId, workOrderVersions[1].UpdatedByUserId);
            Assert.AreEqual(workOrder.Description, dbWorkOrder.Description);
            Assert.AreEqual(workOrder.CorrectedAtLatest.ToString(), dbWorkOrder.CorrectedAtLatest.ToString());
            Assert.AreEqual(workOrder.DoneAt.ToString(), dbWorkOrder.DoneAt.ToString());
            Assert.AreEqual(workOrder.DoneBySiteId, dbWorkOrder.DoneBySiteId);
            Assert.AreEqual(workOrder.DescriptionOfTaskDone, dbWorkOrder.DescriptionOfTaskDone);
        }
    }
}