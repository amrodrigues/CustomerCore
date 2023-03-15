namespace Application.EventSourcedNormalizers
{
    public class CustomerHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string DateOfBirth { get; set; }
        public string Timestamp { get; set; }
        public string Who { get; set; }
    }
}