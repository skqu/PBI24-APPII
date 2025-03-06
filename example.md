@startuml

left to right direction
actor Customer
actor "Restaurant Owner" as Owner
actor Admin

rectangle "order system" {
usecase "Register/Login" as UC1
usecase "Browse Restaurants & Menus" as UC2
usecase "Add Items to Cart" as UC3
usecase "Place Order" as UC4
usecase "Make Payment" as UC5
usecase "Manage Menu" as UC6
usecase "Manage Orders" as UC7
usecase "Monitor System" as UC8
usecase "Manage Users" as UC9
}

Customer --> UC1
Customer --> UC2
Customer --> UC3
Customer --> UC4
Customer --> UC5

Owner --> UC6
Owner --> UC7

Admin --> UC8
Admin --> UC9

@enduml
