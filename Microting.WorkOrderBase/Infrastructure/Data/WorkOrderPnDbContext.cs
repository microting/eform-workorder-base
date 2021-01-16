/*
The MIT License (MIT)

Copyright (c) 2007 - 2020 Microting A/S

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

namespace Microting.WorkOrderBase.Infrastructure.Data
{
    using eFormApi.BasePn.Abstractions;
    using eFormApi.BasePn.Infrastructure.Database.Entities;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class WorkOrderPnDbContext : DbContext, IPluginDbContext
    {
        public WorkOrderPnDbContext() { }

        public WorkOrderPnDbContext(DbContextOptions<WorkOrderPnDbContext> options) : base(options)
        {

        }

        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<WorkOrderVersion> WorkOrderVersions { get; set; }
        public DbSet<AssignedSite> AssignedSites { get; set; }
        public DbSet<AssignedSiteVersion> AssignedSiteVersions { get; set; }
        public DbSet<WorkOrdersTemplateCase> WorkOrdersTemplateCases { get; set; }
        public DbSet<WorkOrdersTemplateCaseVersion> WorkOrdersTemplateCaseVersions { get; set; }
        public DbSet<PicturesOfTask> PicturesOfTasks { get; set; }
        public DbSet<PicturesOfTaskDone> PicturesOfTaskDone { get; set; }
        public DbSet<PluginConfigurationValue> PluginConfigurationValues { get; set; }
        public DbSet<PluginConfigurationValueVersion> PluginConfigurationValueVersions { get; set; }
        public DbSet<PluginPermission> PluginPermissions { get; set; }
        public DbSet<PluginGroupPermission> PluginGroupPermissions { get; set; }
        public DbSet<PluginGroupPermissionVersion> PluginGroupPermissionVersions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AssignedSite>().HasIndex(x => x.SiteMicrotingUid);
            modelBuilder.Entity<AssignedSiteVersion>().HasIndex(x => x.SiteMicrotingUid);
            modelBuilder.Entity<PicturesOfTask>().HasIndex(x => x.FileName);
            modelBuilder.Entity<PicturesOfTaskDone>().HasIndex(x => x.FileName);
        }
    }
}