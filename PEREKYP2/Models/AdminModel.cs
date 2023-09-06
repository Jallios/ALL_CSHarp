namespace PEREKYP2.Models
{
    public class AdminModel
    {
        public List<Auto> autos {get; set;}
        public List<User> users {get;set;}
        public List<HistoryAuto> historyAutos { get; set; }
        public List<PurchaseStatus> purchaseStatuses { get; set; }
        public List<UserRole> userRoles { get; set; }

    }
}
