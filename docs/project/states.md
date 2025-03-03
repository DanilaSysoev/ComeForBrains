``` mermaid
flowchart LR
    MainMenu[Основное меню] --> Camp[Лагерь];
    MainMenu <--> Raid[Рейд];
    Camp <--> Sleep[Сон];
    Sleep --> DefendCamp[Защита лагеря];
    DefendCamp --> Camp;
    Raid --> Camp;
    Camp <--> Store[Склад];
    Camp <--> CityMap[Карта города];
    CityMap <--> PrepareRaid[Подготовка к рейду];
    CityMap <--> WorldMap[Карта мира];
    PrepareRaid --> Raid;
    Raid <--> Inventory[Инвентарь];
    Raid --> Camp;
```
