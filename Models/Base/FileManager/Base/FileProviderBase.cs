using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using Syncfusion.EJ2.Base.PhysicalFileProvider;

#if EJ2_DNX
using System.Web.Mvc;
using System.Web;
#else
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
#endif
#if SyncfusionFramework4_0
using System.IO.Packaging;
#endif

namespace Syncfusion.EJ2.Base
{
public interface FileProviderBase
    {

        object GetFiles(string path, bool showHiddenItems, params object[] data);
            FileManagerResponse CreateFolder(string path, string name, params object[] data);

            FileManagerResponse GetDetails(string path, string[] names, params object[] data);

            FileManagerResponse Remove(string path, string[] names, params object[] data);

            FileManagerResponse Rename(string path, string name, string newName, bool replace = false, params object[] data);

            FileManagerResponse CopyTo(string path, string targetPath, string[] names, string[] replacedItemNames, params object[] data);

            FileManagerResponse MoveTo(string path, string targetPath, string[] names, string[] replacedItemNames, params object[] data);

            FileManagerResponse Search(string path, string searchString, bool showHiddenItems, bool caseSensitive, params object[] data);

            FileStreamResult Download(string path, string[] names, params object[] data);
#if EJ2_DNX
            FileManagerResponse Upload(string path, IList<System.Web.HttpPostedFileBase> uploadFiles, string action, string[] replacedItemNames, params object[] data);
#else
        FileManagerResponse Upload(string path, IList<IFormFile> uploadFiles, string action, string[] replacedItemNames, params object[] data);
#endif

            FileStreamResult GetImage(string path, bool allowCompress, params object[] data);
            void RootFolder(string name);
        }
    
}





