# Inventory System for RPG

## Project Description

An inventory management system for a role-playing game, developed in C# following SOLID principles and using design patterns: Abstract Factory, Builder, Strategy, and State.

## Project Structure

```
InventorySystem/
├── Core/
│   ├── Interfaces/
│   ├── Items/
│   └── States/
├── Factories/
├── Builders/
├── Strategies/
├── Services/
└── Tests/
```

## SOLID Principles

### 1. Single Responsibility Principle (SRP)
- `Inventory` - manages only item storage and basic add/remove operations
- `ItemUsageService` - handles only item usage and equipment
- `ItemUpgradeService` - handles only item upgrades

### 2. Open/Closed Principle (OCP)
- `Inventory` works with `IItem` interface, allowing new item types without code changes
- `ItemUsageService` uses `IUsable` and `IEquippable` interfaces

### 3. Liskov Substitution Principle (LSP)
- All items can be used wherever `IItem` is expected
- All states can be used wherever `IItemState` is expected

### 4. Interface Segregation Principle (ISP)
- `IItem` - minimal interface with common properties
- `IEquippable` - separate interface for equippable items
- `IUsable` - separate interface for usable items

### 5. Dependency Inversion Principle (DIP)
- Services depend on interfaces, not concrete classes
- Factories implement `IItemFactory` interface

## Design Patterns

### 1. Abstract Factory
Provides an interface for creating families of related objects without specifying concrete classes.

```csharp
public interface IItemFactory
{
    IItem CreateItem(string name);
}

public class WeaponFactory : IItemFactory { ... }
public class ArmorFactory : IItemFactory { ... }
public class BlockFactory : IItemFactory { ... }
```

### 2. Builder
Allows creating complex objects step by step.

```csharp
var weapon = new WeaponBuilder()
    .WithName("Legendary Fire Sword")
    .WithDamage(100)
    .WithDamageType(DamageType.Fire)
    .WithDurability(200)
    .Build();
```

All item types now have builders:
- `WeaponBuilder`
- `ArmorBuilder`
- `PotionBuilder`
- `FoodBuilder`
- `JewelryBuilder`
- `BlockBuilder`

### 3. Strategy
Defines a family of algorithms, encapsulates each one, and makes them interchangeable.

#### ContextualUsageStrategy
Two modes of usage:
- **Attack Mode**: Weapons deal damage, potions can be thrown at enemies
- **Utility Mode**: Weapons perform utility actions (mining, chopping, digging), potions provide enhanced effects, blocks can be placed

Example:
```csharp
var attackStrategy = new ContextualUsageStrategy(isAttackMode: true);
var result = usageService.UseItem(pickaxe.Id, attackStrategy);

var utilityStrategy = new ContextualUsageStrategy(isAttackMode: false);
var result = usageService.UseItem(pickaxe.Id, utilityStrategy);
```

### 4. State
Allows an object to alter its behavior when its internal state changes.

#### Item States:
- `NormalItemState` - base state
- `UpgradedItemState` - enhanced stats
- `BrokenItemState` - cannot be used or equipped

#### Inventory States:
- `NormalInventoryState` - can add items
- `OverloadedInventoryState` - cannot add new items

## Item Types

1. **Weapon** - equippable, has damage and damage type
2. **Armor** - equippable, has defense
3. **Potion** - usable, restores health/mana
4. **Food** - usable, restores health and stamina
5. **Jewelry** - equippable as accessory, provides stat bonuses
6. **QuestItem** - special item for quests
7. **Block** - new type, can be placed, has material type

## Running Tests

```bash
dotnet test
```

## Usage Examples

### Creating Items via Factories

```csharp
var weaponFactory = new WeaponFactory();
var weapon = weaponFactory.CreateItem("Fire Sword");

var blockFactory = new BlockFactory();
var block = blockFactory.CreateItem("Stone Block");
```

### Creating Items via Builders

```csharp
var weapon = new WeaponBuilder()
    .WithName("Legendary Sword")
    .WithDamage(100)
    .WithDamageType(DamageType.Fire)
    .WithDurability(200)
    .Build();

var block = new BlockBuilder()
    .WithName("Iron Block")
    .WithMaterial(BlockMaterial.Metal)
    .WithDurability(150)
    .Build();
```

### Working with Inventory

```csharp
var inventory = new Inventory(maxQuantity: 100);
inventory.AddItem(weapon);
inventory.AddItem(block);

var foundWeapon = inventory.FindItemById(weapon.Id);
```

### Item Usage with Strategies

```csharp
var usageService = new ItemUsageService(inventory);

var attackStrategy = new ContextualUsageStrategy(isAttackMode: true);
usageService.UseItem(weapon.Id, attackStrategy);

var utilityStrategy = new ContextualUsageStrategy(isAttackMode: false);
usageService.UseItem(weapon.Id, utilityStrategy);
```

## Changes Log

### Version 2.0

1. **Added Builders for all items:**
   - ArmorBuilder
   - PotionBuilder
   - FoodBuilder
   - JewelryBuilder
   - BlockBuilder

2. **New item type:**
   - Block (with BlockMaterial enum)
   - BlockFactory

3. **Updated ContextualUsageStrategy:**
   - Changed from combat/non-combat to attack/utility modes
   - Weapons can now perform utility actions (mining, chopping, etc.)
   - Potions provide different effects based on mode

4. **Code cleanup:**
   - Removed all comments from codebase
   - Updated WeaponBuilder (removed weight parameter)
