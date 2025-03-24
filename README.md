# PBI24-APPII

## Opsamling

Som udgangspunkt kan der identificeres 4, admin, underviser, studerende og ekstern. 

### User stories


US1: Som bruger vil jeg logge ind for at lave beregninger

### Functional Requirements
FR1.1: Hjemmesiden skal have et login interface
FR1.2: Applikationen skal lave beregninger
FR1.6: Hjemmesiden skal oprette ny bruger
FR1.7: Applikationen skal oprette ny bruger

### NonFunctional requirements
NFR1.1.1: Hjemmeside skal have intuitivt design
NFR1.1.2: Hjemmesiden skal understøttes i forskellige browser
NFR1.1.3: Hjemmesiden skal være responsiv
NFR1.1.4: Applikationen skal udføre authenticate
NFR1.1.5: Applikationen skal udføre authorization
NFR1.2.1: Applikation skal opdatere beregninger baseret på nye input
NFR1.2.2: Applikation skal percistere data
NFR1.1.6: Applikation skal være intern compliant
NFR1.1.7: Hjemmeside skal hash password
NFR1.1.6: Applikationen skal overholde authorization
NFR1.7.1: Applikation skal være GDPR compliant
NFR1.7.2: Applikationen skal percistere bruger



### Use case diagrammer

#### Bruger
Vi har kun en enkelt bruger at forholde os til, nemlig bruger. Han agere også stakeholder. 

#### Use case
Vi har observeret tre use case, brugeroprretelse, login og beregninger. 

´´´
@startuml

left to right direction
actor "Bruger" as u
actor "Bruger" as stakeholder

rectangle Brugeroprettelse {
    usecase "Login as admin" as login
    usecase "Tilgå bruger side" as adminSite
    usecase "Indtast info" as input
    usecase "Opret" as create
    usecase "validate info" as val
    usecase "Hash" as hash
    note "Salt and peber" as n1
}

u --> login
login -left-> adminSite
adminSite -left-> input
input -left-> create
create ..> val : <<include>>
create ..> hash : <<include>>
hash -- n1
create --> stakeholder

@enduml
´´´

### Sequence diagram

´´´
@startuml

actor "bruger" as b

b -> FE : login()
FE -> BE : post backend:PORT/user/login
BE -> DB : SELECT FUNCTIONNAME(userCred)
DB --> BE : bool
BE -> BE : Authorize()
BE --> FE : bool
alt "if authorized"
    FE -> FE : admin page
    FE -> FE : validatePwd()
    FE -> FE : HashPwd()
    FE -> BE : put backend:PORT/user
    activate BE
        BE -> BE : validateUser()
        BE -> DB : INSERT IF NOT EXIST
        DB --> BE : int rows
    deactivate BE
    alt "if rows > 0"
        BE --> FE : true
    else "if rows == 0"
        BE --> FE : false
    end
    FE -> FE : validateCreation()
else "if !authorized"
    FE --> b : error msg
end

@enduml
´´´

´´´
@startuml
FEGate -> API : 
API -> USER : authorizeUser(username, pwd)
USER -> DataHandler : getUser(username)
DataHandler -> DBMS : getUser(username)
DBMS -> MySql : Read("user", username)
MySql --> DBMS : user
DBMS --> DataHandler : user
DataHandler --> USER : user
USER -> USER : Authorize
USER --> API : bool
API -> USER : new User(username, pwd)
USER -> DataHandler : addUser(username, pwd)
DataHandler -> DBMS : addUser(username, pwd)
DBMS -> MySql : Write("user", username)
MySql --> DBMS : status
DBMS --> DataHandler : status
DataHandler --> USER : status
alt "if status == "Success"
    USER --> API : User created
else "elseif status == "User already exist"
    USER --> API : Username already used
else "else"
    USER --> API : Failed
end
@enduml
´´´

´´´
@startuml
class API
{

}
class DataHandler
{
    - DBMS dbms
   + getUser(string username) : List<string>
   + addUser(string username, string password, string userGroup) : string
}
class USER
{
    - username : string
    - password : string
    - userGroup : string
    + authorizeUser(string username, string password) : bool
    - authorize() : bool
    + newUser(string username, string password, string usreGroup) : bool
}
class DBMS
{
    - List<iDB> lDB
    + getUser(string username) : List<string>
    + addUser(string username, string password, string userGroup) : string
}
class MySql
{
    + read(string type, string val) : List<string>
    + write(string type, string val) : bool
}

API "1" -right-o "*" DataHandler
DataHandler "*" -right-o "1" USER
DataHandler "1" --* "1" DBMS
DBMS "1" --* "*" iDB
iDB "1" ..|> "1" MySql

@enduml
´´´