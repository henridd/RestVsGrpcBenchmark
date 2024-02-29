namespace RestMessages
{
    public class ComplexRequest
    {
        public int IntField { get; set; }
        public string StringField { get; set; }
        public ComplexRequestSubcontent SubField { get; set; }
    }

    public class ComplexRequestSubcontent
    {
        public int SubField { get; set; }
    }
}
