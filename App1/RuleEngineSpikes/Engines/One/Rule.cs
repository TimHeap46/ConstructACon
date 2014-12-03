namespace RuleEngineSpikes.Engines.One
{
    public class Rule
    {
        private bool propertySet = false;
        public string PropertyName { get; set; }
        public Operator Operator_ { get; set; }
        public object Value { get; set; }

        public Rule(Operator operator_, object value)
        {
            this.Operator_ = operator_;
            this.Value = value;
        }

        public Rule(string propertyName, Operator operator_, object value)
        {
            this.Operator_ = operator_;
            this.Value = value;
            this.PropertyName = propertyName;
            if (!string.IsNullOrEmpty(propertyName))
                this.propertySet = true;
        }
    }
}