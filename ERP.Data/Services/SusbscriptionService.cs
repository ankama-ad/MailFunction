using ERP.Data.Contex;
using ERP.Data.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Data.Services
{
    public class SusbscriptionService
    {
        private ERPContext dbcontext { get; set; }
        public SusbscriptionService()
        {
            this.dbcontext = new ERPContext();
        }

        public List<IGrouping<int?, SubscriptionDataModel>> GetReportSubscriptions()
        {

           return (from s in dbcontext.ReportSubscriptions
                         join r in dbcontext.Reports
                         on s.ReportId equals r.Id
                         join user in dbcontext.Users on s.UseridEmail equals user.UserId
                         select new SubscriptionDataModel() {
                             WorkspaceId = r.PbiWorkspaceId,
                             ReportId = r.PbiReportId,
                             Email = user.Email,
                             UseridEmail =  s.UseridEmail
                         }
                         ).ToList().GroupBy(c => c.UseridEmail).Select(grp => grp).ToList();

           // return this.dbcontext.ReportSubscriptions.Where(c => c.IsActive).ToList();
        }
    }
}
