namespace LR5.BuilderBurger
{
    public class BurgerDirector
    {
        private readonly IBurgerBuilder _builder;

        public BurgerDirector(IBurgerBuilder builder)
        {
            _builder = builder;
        }

        public void BuildDefault()
        {
            _builder
                .AddCheese()
                .AddTomato().
                AddPickles();
        }

        public void BuildWithBeacon()
        {
            _builder
                .AddTomato()
                .AddBacon()
                .AddLetuce();
        }
    }
}
