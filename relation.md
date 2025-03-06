@startuml

left to right direction
actor Customer

rectangle Order {

usecase "Place Order" as UC1
usecase "Make Payment" as UC2
usecase "Validate Payment Details" as UC3
usecase "Apply Discount" as UC4
}
Customer --> UC1
UC1 --> UC2
UC2 ..> UC3 : <<include>>
UC1 ..> UC4 : <<extend>>

@enduml
