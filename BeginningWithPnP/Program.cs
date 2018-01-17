using BeginningWithPnP.CodeExamples;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeginningWithPnP
{
    class Program
    {
        static void Main(string[] args)
        {

            using (ClientContext ctx = Helpers.ContextHelper.GetClientContext("https://folkis2017.sharepoint.com/sites/Tim"))
            {
                PnP101.CreateAList(ctx, "Tims List From Pnp");
                PnP101.CreateATaskList(ctx, "Tims New Tasklist");
                //PnP101.AddNavigationToLeft(ctx,"Aftonbladet", "https://www.aftonbladet.se/");
                PnP101.CreateSubTeamSite(ctx, "Team SubSite2", "TeamSubSite2");
                PnP101.ChangeLogo(ctx);
               // PnP101.AddFolderToLibrary(ctx);
                PnP101.AddSharepointGroup(ctx);

            }

            Console.WriteLine("press Enter");
            Console.ReadKey();

        }
    }
}
