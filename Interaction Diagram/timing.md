@startuml


robust ":user" as U
robust ":ACSystem" as AC

@0
U is Idle
AC is Idle
@1
U --> AC : pinCode
U is WaitCard
AC is Processing
@3
AC --> U : hasCard
U is WaitAccess
@4
AC --> U : granted
@4.01
U is Idle

@enduml
