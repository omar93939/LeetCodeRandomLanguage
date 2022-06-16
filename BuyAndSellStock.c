int maxProfit(int* prices, int pricesSize){
    int buyIndex = 0;
    int largestProfit = 0;
    int valueAtBuyIndex = prices[0];
    int valueAtSellIndex = 0;
    int currentProfit = 0;
    for (int sellIndex = 1; sellIndex < pricesSize; sellIndex++) {
        valueAtSellIndex = prices[sellIndex];
        if (valueAtSellIndex > valueAtBuyIndex) {
            currentProfit = valueAtSellIndex - valueAtBuyIndex;
            if (currentProfit > largestProfit) {
                largestProfit = currentProfit;
            }
        } else {
            buyIndex = sellIndex;
            valueAtBuyIndex = valueAtSellIndex;
        }
    }
    return largestProfit;
}