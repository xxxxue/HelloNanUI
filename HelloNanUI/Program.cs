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
                      // �ڴ˴����� CEF ����ز���
                  });

                  env.CustomCefCommandLineArguments(commandLine =>
                  {
                      // �ڴ˴�ָ�� CEF �����в���
                  });

              }, app =>
              {
                  // ע��Ŀ¼�е��ļ�
                  app.UseEmbeddedFileResource("http", "local", "wwwroot");
                  //�Զ�ɨ�貢ע�ᵱǰ�����е����з���
                  app.UseDataServiceResource("http", "api");


                  // ָ����������
                  app.UseMainWindow(context => new MainWindow());
              });

            // �����߷���֧��
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