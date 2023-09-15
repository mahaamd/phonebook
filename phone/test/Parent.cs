namespace test
{
    public abstract class Parent
    {
        public string Code { set; get; }
        public string Tell { get; set; }
        public string Address { set; get; }

        public abstract void Show();
        public abstract string ReturnData();

    }


}
