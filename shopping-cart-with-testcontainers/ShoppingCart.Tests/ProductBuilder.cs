namespace ShoppingCart.Tests {
    public class ProductBuilder {
        private string _productName;
        private decimal _cost;
        private decimal _revenue;
        private decimal _tax;

        private ProductBuilder(string productName, decimal cost, decimal revenue, decimal tax) {
            _productName = productName;
            _cost = cost;
            _revenue = revenue;
            _tax = tax;
        }

        public static ProductBuilder TaxFreeWithNoRevenueProduct() {
            return AnyProduct()
                .WithRevenue(0)
                .WithTax(0);
        }

        public static ProductBuilder AnyProduct() {
            return new ProductBuilder("", 0m, 0m, 0m);
        }

        public ProductBuilder Named(string productName) {
            _productName = productName;
            return this;
        }

        public ProductBuilder Costing(decimal cost) {
            _cost = cost;
            return this;
        }

        public ProductBuilder WithRevenue(decimal revenue) {
            _revenue = revenue;
            return this;
        }

        public ProductBuilder WithTax(decimal tax) {
            _tax = tax;
            return this;
        }

        public Product Build() {
            return new Product(_productName, _cost, _revenue, _tax);
        }

        public static ProductBuilder NoRevenueProduct() {
            return AnyProduct()
                .WithRevenue(0);
        }

        public static ProductBuilder NoTaxProduct()
        {
            return AnyProduct()
                .WithTax(0);
        }
    }
}
