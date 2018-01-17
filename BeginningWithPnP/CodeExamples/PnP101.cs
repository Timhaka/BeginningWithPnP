using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeginningWithPnP.CodeExamples
{
    public class PnP101
    {

        public static void CreateAList(ClientContext ctx, string Listname)
        {
            //PnP extension, same as we did yesterday with CSOM.
            if (!ctx.Web.ListExists(Listname))
            {
                ctx.Web.CreateList(ListTemplateType.DocumentLibrary, Listname, false, true, "DavidsPnPList");
            }
            else
            {
                Console.WriteLine("List already exists.");
            }
        }
        
        public static void CreateATaskList(ClientContext ctx, string Listname)
        {
            if (!ctx.Web.ListExists(Listname))
            {
                ctx.Web.CreateList(ListTemplateType.Tasks, Listname, false, true, "TimsNewTaskList");
            }
            else
            {
                Console.WriteLine("TaskList Already exists");
            }
        }

        public static void AddNavigationToLeft(ClientContext ctx, string name, string url)
        {

            var uri = new Uri(url);

            ctx.Web.AddNavigationNode(name, uri, "",OfficeDevPnP.Core.Enums.NavigationType.QuickLaunch, true,false);

           
        }

        public static void CreateSubTeamSite(ClientContext ctx, string sitename, string siteurl)
        {

            var site = new OfficeDevPnP.Core.Entities.SiteEntity()
            {
                Title = sitename,
                Url = siteurl,
                Description = "Site creating for testing purpose",
                Template = "STS#0",
                Lcid = 1033
            };


            if (!ctx.Web.WebExistsByTitle(sitename))
            {
                ctx.Web.CreateWeb(site, true, true);
                Console.WriteLine("Creating New Subsite");
            }
            else
            {
                Console.WriteLine("Site Already exists");
            }
        }

        public static void ChangeLogo(ClientContext ctx)
        {
            ctx.Web.SiteLogoUrl = "https://assets.hongkiat.com/uploads/creative-cat-logos/kit-kat.jpg";
            ctx.Web.Update();
            ctx.ExecuteQuery();
            Console.WriteLine("Done"); 
        }
        public static void AddSharepointGroup(ClientContext ctx)
        {
            //need to also add permissions to be able to see the group, otherwise they are kind of "hidden"
            //also you can make the "group" to an objekt.
            //
            string name = "Test group 20";

            if (!ctx.Web.GroupExists(name))
            {

                ctx.Web.AddGroup(name, "Test group", true);
                //ctx.Web.AddUserToGroup("Test group 20", "Tim@folkis2017.onmicrosoft.com");
                Console.WriteLine("creates a group");
            }
            else
            {
                Console.WriteLine("group exists");
            }
        }
        public static void AddFolderToLibrary(ClientContext ctx)
        {
            List list = ctx.Web.GetListByTitle("Tims List From Pnp");
            list.RootFolder.CreateFolder("Test Folder");
  
        }

        //Davids solutions




    }
}
