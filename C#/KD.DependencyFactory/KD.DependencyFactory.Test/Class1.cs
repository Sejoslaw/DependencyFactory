namespace KD.DependencyFactory.Test
{
    public class Class1 : IClass1
    {
        private int Value { get; set; }

        public int GetValue()
        {
            return Value;
        }

        public void SetValue(int newVal)
        {
            this.Value = newVal;
        }
    }
}
