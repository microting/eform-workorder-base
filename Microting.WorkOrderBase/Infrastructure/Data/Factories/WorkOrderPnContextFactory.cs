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

namespace Microting.WorkOrderBase.Infrastructure.Data.Factories
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class WorkOrderPnContextFactory : IDesignTimeDbContextFactory<WorkOrderPnDbContext>
    {
        public WorkOrderPnDbContext CreateDbContext(string[] args)
        {
            // "Data Source=.\\SQLEXPRESS;Database=work-order-pn;Integrated Security=True"
            //args = new[] { "Server = localhost; port = 3306; Database = work-orders-base-db; user = root; Convert Zero Datetime = true;" };
            var optionsBuilder = new DbContextOptionsBuilder<WorkOrderPnDbContext>();
            if (args.Any())
            {
                if (args.FirstOrDefault().ToLower().Contains("convert zero datetime"))
                {
                    optionsBuilder.UseMySql(args.FirstOrDefault());
                }
                else
                {
                    optionsBuilder.UseSqlServer(args.FirstOrDefault());
                }
            }
            else
            {
                throw new ArgumentNullException("Connection string not present");
            }
            //optionsBuilder.UseSqlServer(@"data source=(LocalDb)\SharedInstance;Initial catalog=work-order-base-tests;Integrated Security=True");
            // dotnet ef migrations add InitialCreate--project Microting.WorkOrderBase--startup - project DBMigrator
            optionsBuilder.UseLazyLoadingProxies(true);
            return new WorkOrderPnDbContext(optionsBuilder.Options);
        }
    }
}