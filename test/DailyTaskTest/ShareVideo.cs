using Microsoft.Extensions.DependencyInjection;
using Ray.BiliBiliTool.Console;
using Ray.BiliBiliTool.DomainService.Interfaces;
using Ray.BiliBiliTool.Infrastructure;
using Xunit;

namespace ShareVideoTest
{
    public class ShareVideo
    {
        [Fact]
        public void Test1()
        {
            Program.Init(new string[] { });

            using (var scope = Global.ServiceProviderRoot.CreateScope())
            {
                var dailyTaskService = scope.ServiceProvider.GetRequiredService<IVideoDomainService>();
                var account = scope.ServiceProvider.GetRequiredService<IAccountDomainService>();

                var dailyTaskStatus = account.GetDailyTaskStatus();

                var aid = dailyTaskService.GetRandomVideoOfRegion().Item1;
                dailyTaskService.ShareVideo(aid);

                Assert.True(true);
            }
        }
    }
}
