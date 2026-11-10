MAR := PC
MRd
CR := MDR
PC := PC + 1
Acc := IR
MAR := PC
MRd
CR := MDR
PC := PC + 1
MAR := ADR
MDR := Acc
MWr
MAR := PC
MRd
CR := MDR
PC := PC + 1
DR := 000.ADR
Acc := Acc / DR
MAR := PC
MRd
CR := MDR
PC := PC + 1
MAR := ADR
MRd
MAR := MDR
MDR := Acc
MWr
MAR := PC
MRd
CR := MDR
PC := ADR
...
Acc := Acc / DR
MWr
PC := ADR
...
Acc := Acc / DR
MWr
PC := ADR