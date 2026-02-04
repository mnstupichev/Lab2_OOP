# Система управления инвентарем для ролевой игры

## Описание проекта

Это система управления инвентарем для ролевой игры, разработанная на C# с соблюдением принципов SOLID и использованием паттернов проектирования: Abstract Factory, Builder, Strategy и State.

## Структура проекта

```
InventorySystem/
├── Core/
│   ├── Interfaces/      # Базовые интерфейсы
│   ├── Items/          # Типы предметов
│   └── States/         # Состояния (State pattern)
├── Factories/          # Abstract Factory
├── Builders/           # Builder pattern
├── Strategies/         # Strategy pattern
├── Services/           # Бизнес-логика
└── Tests/              # Unit тесты
```

## Принципы SOLID

### 1. Single Responsibility Principle (SRP)

**Что это значит:** Каждый класс должен иметь только одну причину для изменения.

**Примеры в проекте:**
- `Inventory` - отвечает только за хранение предметов и базовые операции добавления/удаления
- `ItemUsageService` - отвечает только за использование и экипировку предметов
- `ItemUpgradeService` - отвечает только за улучшение предметов

**Почему это важно:** Если нужно изменить логику использования предметов, мы меняем только `ItemUsageService`, не затрагивая другие части системы.

### 2. Open/Closed Principle (OCP)

**Что это значит:** Классы должны быть открыты для расширения, но закрыты для модификации.

**Примеры в проекте:**
- `Inventory` работает с интерфейсом `IItem`, поэтому можно добавлять новые типы предметов (например, `Scroll`, `Book`) без изменения кода `Inventory`
- `ItemUsageService` использует интерфейсы `IUsable` и `IEquippable`, поэтому можно добавлять новые способы использования через Strategy без изменения сервиса

**Пример добавления нового типа предмета:**
```csharp
public class Scroll : BaseItem, IUsable
{
    // Реализация без изменения Inventory или других сервисов
}
```

### 3. Liskov Substitution Principle (LSP)

**Что это значит:** Объекты подклассов должны заменять объекты базовых классов без нарушения функциональности программы.

**Примеры в проекте:**
- Все предметы (`Weapon`, `Armor`, `Potion`, `Food`, `Jewelry`, `QuestItem`) могут использоваться везде, где ожидается `IItem`
- Все состояния (`NormalItemState`, `UpgradedItemState`, `BrokenItemState`) могут использоваться везде, где ожидается `IItemState`

**Почему это важно:** Мы можем безопасно работать с коллекцией `IItem`, не зная конкретных типов предметов.

### 4. Interface Segregation Principle (ISP)

**Что это значит:** Клиенты не должны зависеть от интерфейсов, которые они не используют.

**Примеры в проекте:**
- `IItem` - минимальный интерфейс с общими свойствами
- `IEquippable` - отдельный интерфейс для экипируемых предметов
- `IUsable` - отдельный интерфейс для используемых предметов

**Почему это важно:** `QuestItem` не реализует `IUsable` или `IEquippable`, потому что квестовые предметы нельзя использовать или экипировать. Это предотвращает ошибки и делает код более понятным.

### 5. Dependency Inversion Principle (DIP)

**Что это значит:** Модули высокого уровня не должны зависеть от модулей низкого уровня. Оба должны зависеть от абстракций.

**Примеры в проекте:**
- `ItemUsageService` зависит от интерфейсов `IUsable` и `IEquippable`, а также поддерживает `IItemUsageStrategy` для альтернативных способов использования
- Фабрики реализуют интерфейс `IItemFactory`
- Сервисы работают с интерфейсами `IItem`, `IEquippable`, `IUsable`

**Почему это важно:** Мы можем легко заменить реализацию стратегии улучшения или фабрики без изменения кода, который их использует.

## Паттерны проектирования

### 1. Abstract Factory (Абстрактная фабрика)

**Что это:** Паттерн, который предоставляет интерфейс для создания семейств связанных объектов без указания их конкретных классов.

**Проблема, которую решает:**
Нужно создавать разные типы предметов (оружие, броня, зелья и т.д.), но мы не хотим зависеть от конкретных классов. Также может быть несколько "семейств" фабрик: например, фабрика для обычных предметов и фабрика для легендарных предметов.

**Пример из реальной жизни:**
Производство мебели: есть абстрактная фабрика "Мебель", которая создает стулья, столы, шкафы. Конкретные фабрики: "Викторианская мебель" (создает викторианские стулья, столы, шкафы) и "Современная мебель" (создает современные стулья, столы, шкафы). Клиент работает с абстрактной фабрикой и получает согласованный стиль мебели.

**В нашем проекте:**
```csharp
public interface IItemFactory
{
    IItem CreateItem(string name);
}

// Конкретные фабрики
public class WeaponFactory : IItemFactory { ... }
public class ArmorFactory : IItemFactory { ... }
public class PotionFactory : IItemFactory { ... }
```

**Преимущества:**
- Изоляция конкретных классов от клиента
- Легко добавить новую фабрику (например, `LegendaryItemFactory`)
- Обеспечивает согласованность создаваемых объектов

**Как использовать:**
```csharp
IItemFactory factory = new WeaponFactory();
IItem weapon = factory.CreateItem("Sword");
```

### 2. Builder (Строитель)

**Что это:** Паттерн, который позволяет создавать сложные объекты пошагово.

**Проблема, которую решает:**
Когда объект имеет много параметров (оружие с уроном, типом урона, прочностью, эффектами и т.д.), конструктор становится перегруженным. Также некоторые параметры могут быть опциональными, и создавать множество перегрузок конструктора неудобно.

**Пример из реальной жизни:**
Строительство дома: есть строитель (Builder), который может установить фундамент, стены, крышу, окна по отдельности. В конце вызывается метод "построить дом", и получается готовый дом со всеми установленными компонентами.

**В нашем проекте:**
```csharp
var weapon = new WeaponBuilder()
    .WithName("Legendary Fire Sword")
    .WithDamage(100)
    .WithDamageType(DamageType.Fire)
    .WithWeight(5.0)
    .WithDurability(200)
    .Build();
```

**Преимущества:**
- Позволяет создавать объекты пошагово
- Можно использовать разные представления одного объекта
- Изолирует сложный код построения объекта

**Как использовать:**
```csharp
var builder = new WeaponBuilder();
builder.WithName("Sword")
       .WithDamage(50)
       .WithDamageType(DamageType.Physical);
Weapon weapon = builder.Build();
```

### 3. Strategy (Стратегия)

**Что это:** Паттерн, который определяет семейство алгоритмов, инкапсулирует каждый из них и делает их взаимозаменяемыми.

**Проблема, которую решает:**
Один предмет может использоваться разными способами в зависимости от контекста или выбора игрока (например, зелье можно выпить или бросить во врага). Без паттерна Strategy пришлось бы использовать множество if-else или switch-case, что нарушает Open/Closed Principle.

**Пример из реальной жизни:**
Оплата в интернет-магазине: есть стратегии оплаты (CreditCardStrategy, PayPalStrategy, BitcoinStrategy). Покупатель выбирает способ оплаты, и система использует соответствующую стратегию. Добавление нового способа оплаты не требует изменения кода обработки заказов.

**В нашем проекте:**
```csharp
public interface IItemUsageStrategy
{
    bool CanUse(IItem item);
    UseResult Use(IItem item);
    string StrategyName { get; }
}

// Конкретные стратегии использования
public class ConsumeUsageStrategy : IItemUsageStrategy { ... }  // Потребление
public class EquipUsageStrategy : IItemUsageStrategy { ... }    // Экипировка
public class ThrowUsageStrategy : IItemUsageStrategy { ... }     // Бросок
public class ContextualUsageStrategy : IItemUsageStrategy { ... } // Контекстное использование
```

**Преимущества:**
- Легко добавлять новые способы использования предметов
- Можно менять стратегию во время выполнения
- Изолирует алгоритмы использования от кода, который их использует
- Один предмет может использоваться по-разному в зависимости от контекста

**Как использовать:**
```csharp
var usageService = new ItemUsageService(inventory);

// Стандартное использование через интерфейс
var result1 = usageService.UseItem(potion.Id); // Выпивает зелье

// Использование через Strategy (бросить зелье)
var throwStrategy = new ThrowUsageStrategy();
var result2 = usageService.UseItem(potion.Id, throwStrategy); // Бросает зелье

// Контекстное использование (в бою/вне боя)
var combatStrategy = new ContextualUsageStrategy(isInCombat: true);
var result3 = usageService.UseItem(potion.Id, combatStrategy); // Использует в бою
```

### 4. State (Состояние)

**Что это:** Паттерн, который позволяет объекту изменять свое поведение в зависимости от внутреннего состояния.

**Проблема, которую решает:**
Предмет может находиться в разных состояниях (нормальный, улучшенный, сломанный), и в каждом состоянии он ведет себя по-разному. Без паттерна State пришлось бы использовать множество if-else или switch-case, что усложняет код и нарушает OCP.

**Пример из реальной жизни:**
Светофор: состояния "Красный", "Желтый", "Зеленый". В каждом состоянии светофор ведет себя по-разному (разрешает или запрещает движение), и знает, в какое состояние перейти дальше.

**В нашем проекте:**

**4.1. State для предметов:**
```csharp
public interface IItemState
{
    string Name { get; }
    double StatModifier { get; }
    bool CanUse { get; }
    bool CanEquip { get; }
}

// Конкретные состояния
public class NormalItemState : IItemState { ... }
public class UpgradedItemState : IItemState { ... }
public class BrokenItemState : IItemState { ... }
```

**4.2. State для инвентаря:**
```csharp
public interface IInventoryState
{
    bool CanAddItem(IItem item, double currentWeight, double maxWeight);
    bool CanRemoveItem();
}

// Конкретные состояния
public class NormalInventoryState : IInventoryState { ... }
public class OverloadedInventoryState : IInventoryState { ... }
```

**Преимущества:**
- Локализует поведение, зависящее от состояния
- Упрощает переходы между состояниями
- Убирает множественные условные операторы

**Как использовать:**
```csharp
// Предмет в нормальном состоянии
weapon.State = new NormalItemState();
int damage = weapon.GetCurrentDamage(); // Базовый урон

// Улучшаем предмет
weapon.State = new UpgradedItemState(1.5);
int upgradedDamage = weapon.GetCurrentDamage(); // Урон * 1.5

// Предмет сломался
weapon.State = new BrokenItemState();
weapon.Equip(); // Выбросит исключение - нельзя экипировать сломанный предмет
```

## Типы предметов

1. **Weapon (Оружие)** - экипируется, имеет урон и тип урона
2. **Armor (Броня)** - экипируется, имеет защиту
3. **Potion (Зелье)** - используется, восстанавливает здоровье/ману и т.д.
4. **Food (Еда)** - используется, восстанавливает здоровье и выносливость
5. **Jewelry (Ювелирные изделия)** - экипируется как аксессуар, дает бонусы к характеристикам
6. **QuestItem (Квестовый предмет)** - специальный предмет для квестов

## Запуск тестов

```bash
dotnet test
```

## Примеры использования

### Создание предметов через фабрики

```csharp
var weaponFactory = new WeaponFactory();
var weapon = weaponFactory.CreateItem("Fire Sword");

var armorFactory = new ArmorFactory();
var armor = armorFactory.CreateItem("Plate Armor");
```

### Создание предметов через Builder

```csharp
var weapon = new WeaponBuilder()
    .WithName("Legendary Sword")
    .WithDamage(100)
    .WithDamageType(DamageType.Fire)
    .WithDurability(200)
    .WithState(new UpgradedItemState(2.0))
    .Build();
```

### Работа с инвентарем

```csharp
var inventory = new Inventory(maxWeight: 100.0);
inventory.AddItem(weapon);
inventory.AddItem(armor);

var foundWeapon = inventory.FindItemById(weapon.Id);
var allWeapons = inventory.FindItemsByType<Weapon>();
```

### Использование и экипировка предметов

```csharp
var usageService = new ItemUsageService(inventory);
usageService.EquipItem(weapon.Id);
usageService.UseItem(potion.Id);
```

### Улучшение предметов

```csharp
var upgradeService = new ItemUpgradeService(inventory, upgradeModifier: 1.5);
var result = upgradeService.UpgradeItem(weapon.Id);

if (result.Success)
{
    Console.WriteLine(result.Message); // "Sword has been upgraded! Stats increased by 50%"
}
```

## Заключение

Проект демонстрирует применение принципов SOLID и паттернов проектирования для создания гибкой и расширяемой системы управления инвентарем. Каждый компонент имеет четкую ответственность, и система легко расширяется новыми типами предметов, способами использования и состояниями.
