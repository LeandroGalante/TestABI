# 🚀 Quick Start - Sales API

Quick guide to run and test the Sales API in minutes.

## ⚡ Setup and Run

### ✅ Visual Studio (Recommended - Works!)
```bash
# 1. Open solution in Visual Studio
start Ambev.DeveloperEvaluation.sln

# 2. Set startup project: Ambev.DeveloperEvaluation.WebApi
# 3. Press F5 (Debug)
```

**This will start the API on `https://localhost:7080`**

### ❌ Docker (Has Issues)
```bash
# Known issues with container not staying up
# Use Visual Studio instead
docker-compose up --build
```

## 🎯 Test Endpoints

### Create Sale (POST)
```bash
curl -X POST "https://localhost:7080/api/sales" \
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

### List Sales (GET)
```bash
curl -X GET "https://localhost:7080/api/sales?page=1&size=10"
```

## 📊 Business Rules Testing

| Quantity | Expected Discount |
|----------|-------------------|
| 1-3 items | 0% (no discount) |
| 4-9 items | 10% discount     |
| 10-20 items | 20% discount   |
| 21+ items | ❌ ERROR         |

## 🔧 Important URLs

- **API**: `https://localhost:7080/api/sales`
- **Swagger**: `https://localhost:7080/swagger`
- **Health**: `https://localhost:7080/health`

## 📋 Quick Check

- [ ] ✅ Visual Studio running (F5)
- [ ] ✅ Create sale successfully
- [ ] ✅ Discounts applied correctly
- [ ] ✅ Events logged in console
- [ ] ✅ List sales working
- [ ] ✅ Error for 21+ items

**🎉 Done! Use Visual Studio - it works perfectly!** 