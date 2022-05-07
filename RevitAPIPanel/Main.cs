using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RevitAPIPanel
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "RevitAPIPanel";
            application.CreateRibbonTab(tabName);
            string utilsFolderPath = @"C:\RevitAPITrainig\";

            var panel = application.CreateRibbonPanel(tabName, "Количество");

            var button = new PushButtonData("Элементы", "Посчитать", 
                Path.Combine(utilsFolderPath, "RevitAPI3Buttom.dll"), 
                "RevitAPI3Buttom.Main");
            Uri uriImage = new Uri(@"C:\Users\prova\source\repos\RevitAPIPanel\RevitAPIPanel\Images\RevitAPITrainingUI_32.png", UriKind.Absolute);
            BitmapImage largeImage = new BitmapImage(uriImage);
            button.LargeImage = largeImage;

            panel.AddItem(button);


            var panel2 = application.CreateRibbonPanel(tabName, "Задать");

            var button2 = new PushButtonData("Стены", "Тип стен", 
                Path.Combine(utilsFolderPath, "RevitAPITypeWall.dll"), 
                "RevitAPITypeWall.Main");

            Uri uriImage2 = new Uri(@"C:\Users\prova\source\repos\RevitAPIPanel\RevitAPIPanel\Images\RevitAPITrainingUI_32.png", UriKind.Absolute);
            BitmapImage largeImage2 = new BitmapImage(uriImage2);
            button2.LargeImage = largeImage2;

            panel2.AddItem(button2);


            return Result.Succeeded;
        }
    }
}
