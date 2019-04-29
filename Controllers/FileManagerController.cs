using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using System.Web.Hosting;
using Syncfusion.EJ2.Base.PhysicalFileProvider;
using Syncfusion.EJ2.Base;
using Newtonsoft.Json;

namespace EJ2FileManagerService.Controllers
{
    public class FileManagerController : Controller
    {

        public ActionResult FileManager()
        {
            return View();
        }

        PhysicalFileProvider operation = new PhysicalFileProvider();
        public FileManagerController()
        {
            this.operation.RootFolder(HostingEnvironment.MapPath("~/Content/Files"));
        }

        public ActionResult FileActionDefault(FMParams args)
        {

            switch (args.action)
            {
                case "Read":
                    return Json(operation.ToCamelCase(operation.GetFiles(args.path, false)));
                case "Remove":
                    return Json(operation.ToCamelCase(operation.Remove(args.path, args.itemNames)));
                case "GetDetails":
                    return Json(operation.ToCamelCase(operation.GetDetails(args.path, args.itemNames)));
                case "CreateFolder":
                    return Json(operation.ToCamelCase(operation.CreateFolder(args.path, args.name)));
                case "Search":
                    return Json(operation.ToCamelCase(operation.Search(args.path, args.searchString, args.showHiddenItems, args.caseSensitive)));
                case "Rename":
                    return Json(operation.ToCamelCase(operation.Rename(args.path, args.name, args.itemNewName)));
            }
            return null;

        }
        public ActionResult Upload(string path, IList<System.Web.HttpPostedFileBase> uploadFiles, string action)
        {
            FileManagerResponse uploadResponse;
            uploadResponse = operation.Upload(path, uploadFiles, action, null);

            return Content("");
        }

        public ActionResult Download(string downloadInput)
        {
            FMParams args = JsonConvert.DeserializeObject<FMParams>(downloadInput);
            return operation.Download(args.path, args.itemNames);

        }


        public ActionResult GetImage(FMParams args)
        {
            return this.operation.GetImage(args.path, false);
        }


    
    }
    public class FMParams
    {
        public string action { get; set; }

        public string path { get; set; }

        public string targetPath { get; set; }

        public bool showHiddenItems { get; set; }

        public string[] itemNames { get; set; }

        public string name { get; set; }

        public bool caseSensitive { get; set; }


        public string searchString { get; set; }

        public string itemNewName { get; set; }


        public object[] data { get; set; }
    }
}