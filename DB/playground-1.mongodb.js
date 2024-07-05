/*Create new collection*/
// db.createCollection("users")

/*Insert new documents*/
/*db.users.insertMany([
    {
        "name": "John",
        "age": 20,
        "email": "johny@example.com",
        "phone": "1234567890",
        "address": {
            "city": "New York",
            "state": "NY",
            "country": "USA"
        }
    },
    {
        "name": "Alice",
        "age": 25,
        "email": "alices@example.com",
        "phone": "9876543210",
        "address": {
            "city": "Los Angeles",
            "state": "CA",
            "country": "USA"
        }
    }
])*/

// db.createCollection("House")

// db.House.insertMany([
//     {
//         "HouseName": "House 1",
//         "HouseType": "Single Family",
//         "HousePrice": 100000,
//         "HouseAddress": {
//             "city": "New York",
//             "state": "NY",
//             "country": "USA"
//         }
//     },
//     {
//         "HouseName": "House 2",
//         "HouseType": "Condo",
//         "HousePrice": 200000,
//         "HouseAddress": {
//             "city": "Los Angeles",
//             "state": "CA",
//             "country": "USA"
//         }
//     }
// ])

db.createCollection("Contracts")

db.Contracts.insertMany([
    {
        "ContractDate": "2021-01-01",
        "Owner": "John",
        "HouseId": ObjectId("667adff32e1baeee884068df"),
        "UserId": ObjectId("6678c3792216286bb920449a")
    },
    {
        "ContractDate": "2021-01-02",
        "Owner": "Alice",
        "HouseId": ObjectId("667adff32e1baeee884068df"),
        "UserId": ObjectId("6678c3792216286bb920449a")
    }
])