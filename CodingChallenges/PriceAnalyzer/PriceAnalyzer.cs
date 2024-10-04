class PriceAnalyzer
{
    private readonly Dictionnary<double, int> PricesCount;
    private Queue<double> PricesOrder;
    public PriceAnalyzer()
    {
        this.PricesCount = new Dictionnary<double, int>();
        this.PricesOrder = new Queue<double>();
    }

    void AddPrice(double price)
    {
        if (PricesCount.ContainsKey(price))
        {
            PricesCount[price]++;
        }
        else PricesCount.Add(price, 1);

        PricesOrder.Enqueue(price);

    }
    void RemovePrice()
    {
        if (PricesOrder.Count == 0) return;
        double oldestPrice = PricesOrder.Dequeue();
        if (PricesCount[oldestPrice] > 1) PricesCount[oldestPrice]--;
        else PricesCount.Remove(oldestPrice);

    }
    double Mode()
    {
        if (PricesCount.Count == 0) return double.NaN;
        double mostFrequentPrice = 0; int maxCount = 0;
        foreach (var price in PricesCount)
        {
            if (price.Value > maxCount)
            {
                mostFrequentPrice = price.Key;
                maxCount = price.Value;
            }

        }
        return mostFrequentPrice;

    }
}