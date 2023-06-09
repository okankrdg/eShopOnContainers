namespace WebMVC.Services.ModelDTOs;

public record OrderProcessAction
{
    public string Code { get; }
    public string Name { get; }

    public static OrderProcessAction Ship = new OrderProcessAction(nameof(Ship).ToLowerInvariant(), "Ship");
    public static OrderProcessAction Completed = new OrderProcessAction(nameof(Completed).ToLowerInvariant(), "Completed");

    protected OrderProcessAction()
    {
    }

    public OrderProcessAction(string code, string name)
    {
        Code = code;
        Name = name;
    }
}
