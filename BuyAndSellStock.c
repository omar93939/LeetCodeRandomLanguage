int maxProfit(int* prices, int pricesSize){
    int last = 10001;
    int currentBuy = 0;
    int largestProfit = 0;
    int largestDifference = 0;
    int currentDifference = 0;
    for (int i = 0, len = pricesSize - 1; i < len; i++) {
        currentBuy = prices[i];
        if (currentBuy < last) {
            largestDifference = 0;
            for (int j = i + 1; j < pricesSize; j++) {
                currentDifference = prices[j] - currentBuy;
                if (currentDifference > largestDifference) {
                    largestDifference = currentDifference;
                }
            }
            if (largestDifference > largestProfit) {
                largestProfit = largestDifference;
            }
            last = currentBuy;
        }
    }
    return largestProfit;
}