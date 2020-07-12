namespace WildFarm.Models.Contracts
{
    interface IAnimal
    {
        public string Name { get; set; }
        public string AskForFood();

    }
}
