# 🚀 Quick Start - Sales API

Quick guide to run and test the Sales API in minutes.

## ⚡ Setup and Run

### Visual Studio
```bash
# 1. Open solution in Visual Studio
start Ambev.DeveloperEvaluation.sln

# 2. Set startup project: Ambev.DeveloperEvaluation.WebApi
# 3. Press F5 (Debug)
```

**API will be available at: `https://localhost:7181`**

## 🎯 Test Endpoints

### Create Sale
```bash
curl -k -X POST "https://localhost:7181/api/sales" \
-H "Content-Type: application/json" \
-d '{
  "saleNumber": "SALE-001",
  "saleDate": "2024-12-04T10:00:00Z",
  "customerId": "CUST-001",
  "customerName": "John Doe",
  "branchId": "BRANCH-001",
  "branchName": "Main Branch",
  "items": [
    {
      "productId": "PROD-001",
      "productName": "Beer 350ml",
      "quantity": 5,
      "unitPrice": 3.50
    }
  ]
}'
```

### List Sales
```bash
curl -k -X GET "https://localhost:7181/api/sales?page=1&size=10"
```

### Health Check
```bash
curl -k -X GET "https://localhost:7181/health"
```

## 📊 Business Rules

| Quantity | Expected Discount |
|----------|-------------------|
| 1-3 items | 0% (no discount) |
| 4-9 items | 10% discount     |
| 10-20 items | 20% discount   |
| 21+ items | ❌ ERROR         |

## 🔧 Important URLs

- **API**: `https://localhost:7181/api/sales`
- **Swagger**: `https://localhost:7181/swagger`
- **Health**: `https://localhost:7181/health`

**Note**: Use `-k` flag in curl to skip SSL certificate verification for development.

**🎉 Done! Press F5 in Visual Studio and test with curl commands above.** 