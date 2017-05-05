[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(HR_TrackingTool.MVCGridConfig), "RegisterGrids")]

namespace HR_TrackingTool
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq.Expressions;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity;
    
    using MVCGrid.Models;
    using MVCGrid.Web;
    using HR_TrackingTool.Models;


    public static class MVCGridConfig
    {
        public static void RegisterGrids()
        {


           
 //MVCGridDefinitionTable.Add("Grid1", new MVCGridBuilder<Detail>()
 //                       .WithAuthorizationType(AuthorizationType.AllowAnonymous)
 //                       .AddColumns(cols =>
 //                       {
 //                           cols.Add().WithColumnName("First_Name")
 //                                       .WithHeaderText("First Name")
 //                                       .WithValueExpression(i => i.First_Name);
 //                           cols.Add().WithColumnName("Last_Name")
 //                                      .WithHeaderText("Last Name")
 //                                      .WithValueExpression(i => i.Last_Name);
 //                           cols.Add().WithColumnName("Email")
 //                                      .WithHeaderText("Email")
 //                                      .WithValueExpression(i => i.Email);
 //                           cols.Add().WithColumnName("Ph_Number")
 //                                     .WithHeaderText("Phone Number")
 //                                     .WithValueExpression(i => i.Ph_Number.ToString());
 //                       }).WithPreloadData(true)
 //   .WithSorting(true, "Last_Name")
 //   .WithSorting(true, "First_Name")
 //   .WithPaging(true, 10)
 //   .WithPageParameterNames("Active")
 //   .WithRetrieveDataMethod((context) =>
 //   {
 //       var options = context.QueryOptions;
 //       int totalRecords;
 //       var repo = DependencyResolver.Current.GetService<>();
 //       string ppactive = options.GetPageParameterString("active");
 //       bool filterActive = bool.Parse(ppactive);
 //       var items = repo.GetData(out totalRecords, null, null, filterActive, options.GetLimitOffset(), options.GetLimitRowcount(),
 //           options.GetSortColumnData<string>(), options.SortDirection == SortDirection.Dsc);
 //       return new QueryResult<Detail>()
 //       {
 //           Items = items,
 //           TotalRecords = totalRecords
 //       };


 //   })
 //                           );
            
                        }
        /*
        MVCGridDefinitionTable.Add("UsageExample", new MVCGridBuilder<YourModelItem>()
            .WithAuthorizationType(AuthorizationType.AllowAnonymous)
            .AddColumns(cols =>
            {
                // Add your columns here
                cols.Add().WithColumnName("UniqueColumnName")
                    .WithHeaderText("Any Header")
                    .WithValueExpression(i => i.YourProperty); // use the Value Expression to return the cell text for this column
                cols.Add().WithColumnName("UrlExample")
                    .WithHeaderText("Edit")
                    .WithValueExpression((i, c) => c.UrlHelper.Action("detail", "demo", new { id = i.Id }));
            })
            .WithRetrieveDataMethod((context) =>
            {
                // Query your data here. Obey Ordering, paging and filtering parameters given in the context.QueryOptions.
                // Use Entity Framework, a module from your IoC Container, or any other method.
                // Return QueryResult object containing IEnumerable<YouModelItem>

                return new QueryResult<YourModelItem>()
                {
                    Items = new List<YourModelItem>(),
                    TotalRecords = 0 // if paging is enabled, return the total number of records of all pages
                };

            })
        );
        */
    }
    }

