public class PrimitiveCalculator : ICalculator
{
    private IStrategy strategy;
    private char @operator;

    public PrimitiveCalculator()
    {
        this.@operator = '+';
        this.strategy = new AdditionStrategy();
    }

    public void ChangeStrategy(char @operator)
    {
        switch (@operator)
        {
            case '+':
                this.strategy = new AdditionStrategy();
                break;
            case '-':
                this.strategy = new SubtractionStrategy();
                break;
            case '*':
                this.strategy = new MultiplyStrategy();
                break;
            case '/':
                this.strategy = new DevideStrategy();
                break;
        }

        this.@operator = @operator;
    }

    public int PerformCalculation(int firstOperand, int secondOperand)
    {
        return this.strategy.Calculate(firstOperand, secondOperand);
    }
}
