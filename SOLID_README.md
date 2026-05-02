# 🧱 SOLID Principles

> A simple, visual guide to the 5 SOLID principles — with real-world analogies (no code!)

---

## What is SOLID?

**SOLID** is a set of 5 design principles that help you write software that is:
- ✅ Easy to understand
- ✅ Easy to maintain
- ✅ Easy to extend
- ✅ Less likely to break when changed

---

## The 5 Principles

---

### S — Single Responsibility Principle (SRP)

> **"A class should have one, and only one, reason to change."**

#### 🌍 Real-World Analogy:
Think of a **chef** at a restaurant.
The chef's only job is to **cook food**.

If you also make the chef:
- Take orders from customers
- Handle payments
- Clean the tables

...the chef becomes overwhelmed, and if **any one of those tasks changes**, you have to retrain the chef entirely.

**Solution:** Each person (class) should have **one job only**.

---

### O — Open/Closed Principle (OCP)

> **"A class should be open for extension, but closed for modification."**

#### 🌍 Real-World Analogy:
Think of a **smartphone**.

When a new app comes out, you **install it** — you don't open up the phone and rewire the hardware.

The phone is:
- **Closed** for modification (you don't change the hardware)
- **Open** for extension (you can add new apps anytime)

**Solution:** Add new features by **extending**, not by editing existing, working code.

---

### L — Liskov Substitution Principle (LSP)

> **"Subtypes must be substitutable for their base types."**

#### 🌍 Real-World Analogy:
Think of **vehicles** at a car rental.

If you rent a "vehicle," you expect it to **drive on the road**.

If someone hands you a **boat** and calls it a "vehicle" — that's a problem. A boat can't substitute a car, even though both are modes of transport.

**Solution:** A child class should be able to **replace** its parent class without breaking anything.

---

### I — Interface Segregation Principle (ISP)

> **"Don't force a class to implement interfaces it doesn't use."**

#### 🌍 Real-World Analogy:
Think of a **job contract**.

If you hire a **graphic designer**, their contract should cover:
- Design tasks ✅

It should NOT force them to also:
- Fix the office plumbing 🔧
- Drive the company truck 🚛

Forcing irrelevant responsibilities = bad contract (bad interface).

**Solution:** Create **small, specific interfaces** — each class only signs the contract it actually needs.

---

### D — Dependency Inversion Principle (DIP)

> **"High-level modules should not depend on low-level modules. Both should depend on abstractions."**

#### 🌍 Real-World Analogy:
Think of a **power outlet** in your home.

Your lamp doesn't care if the electricity comes from:
- A power plant ⚡
- Solar panels ☀️
- A generator 🔋

The lamp just plugs into the **standard outlet (abstraction)** — it doesn't depend on *where* the power comes from.

**Solution:** Depend on **interfaces/abstractions**, not on concrete implementations.

---

## 📋 Quick Summary

| Letter | Principle | In One Sentence |
|--------|-----------|-----------------|
| **S** | Single Responsibility | One class = one job |
| **O** | Open/Closed | Extend, don't modify |
| **L** | Liskov Substitution | Child classes must work like their parent |
| **I** | Interface Segregation | Don't force unnecessary responsibilities |
| **D** | Dependency Inversion | Depend on abstractions, not implementations |

---

## 💡 Why SOLID Matters

Without SOLID principles, your code becomes:
- 🍝 **Spaghetti code** — hard to follow
- 🧨 **Fragile** — one change breaks everything
- 🔒 **Rigid** — hard to extend or reuse

With SOLID principles, your code becomes:
- 📦 **Modular** — easy to isolate and test
- 🔧 **Maintainable** — easy to fix and update
- 🚀 **Scalable** — easy to grow without breaking things

---

## 📁 Code Examples

> Check the `/examples` folder for C# code examples showing each principle being violated ❌ and then correctly applied ✅.

---

## 🙌 Contributing

Feel free to open a PR or an issue if you'd like to improve the examples or add analogies in other languages!

---

## 📜 License

MIT License — free to use, share, and learn from!
