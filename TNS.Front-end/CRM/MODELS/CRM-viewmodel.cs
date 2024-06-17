namespace TNS.Front_end.CRM.MODELS
{
    public class CRM_viewmodel
    {
        public string Id { get; set; }
        public string SubscriberNumber {get; set; }
        public string PersonalBill { get; set; }
        public string TypeOfEquipment { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public string Service { get; set; }
        public string ServiceProvided { get; set; }
        public string ServiceType { get; set; }
        public string Status { get; set; }
        public string TypeOfProblem { get; set; }
        public string ProblemDescription { get; set; }
    }
}
