using NetDimension.NanUI;
using NetDimension.NanUI.DataServiceResource;
using NetDimension.NanUI.EmbeddedFileResource;
using NetDimension.NanUI.HostWindow;

namespace HelloNanUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {

            var app = WinFormium.CreateRuntimeBuilder(env =>
              {

                  env.CustomCefSettings(settings =>
                  {
                      // 在此处设置 CEF 的相关参数
                  });

                  env.CustomCefCommandLineArguments(commandLine =>
                  {
                      // 在此处指定 CEF 命令行参数
                  });

              }, app =>
              {
                  // 注册目录中的文件
                  app.UseEmbeddedFileResource("http", "local", "wwwroot");
                  //自动扫描并注册当前程序集中的所有服务
                  app.UseDataServiceResource("http", "api");


                  // 指定启动窗体
                  app.UseMainWindow(context => new MainWindow());
              });

            // 开启高分屏支持
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

            app.Build().Run();
        }
        public class MainWindow : Formium
        {
            public override HostWindowType WindowType => HostWindowType.System;

            public override string StartUrl => "http://local/index.html";

            public MainWindow()
            {
                Size = new Size(1024, 768);
            }
            
            protected override void OnReady()
            {
               ShowDevTools();
                base.OnReady();
            }
        }
    }
}