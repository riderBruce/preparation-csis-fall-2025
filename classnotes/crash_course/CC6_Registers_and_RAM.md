# 📘 Registers and RAM

Crash Course Computer Science #6

In this episode, we explore how computers store and retrieve information, focusing on registers and RAM (Random Access Memory).

## 🧠 Memory Basics

The ALU (Arithmetic Logic Unit) needs a place to store results — that's where memory comes in.

## ✅ Latches

AND-OR Latch: A circuit that stores 1 bit of information.

Uses Set, Reset, AND, OR, and NOT gates.

It's called a “latch” because it holds on to a value.

## ✅ Gated Latch

An improved latch that includes:

Write Enable – controls when data can change.

Data In and Data Out lines.

Only updates data when Write Enable is active.

## 🏗️ Registers

A register is a group of gated latches.

Register width refers to how many bits it can store:

8-bit register → stores 8 binary digits.

Modern registers go up to 16, 32, 64 bits, etc.

## 🧮 Register Matrix Example

A 256-bit register could be designed as a 16×16 matrix of latches.

This structure reduces the number of control wires:

1 wire for data, 1 for write enable, 1 for read enable, 16 for rows, 16 for columns.

Controlled with an 8-bit address (4 bits for row + 4 bits for column).

## 🧠 RAM (Random Access Memory)

Memory where each storage location can be randomly accessed.

Modern RAM is made up of millions of tiny registers.

## 🟦 SRAM (Static RAM)

Faster and more stable, but expensive.

Often used in CPU caches.

## 🎯 Final Thought

Even though today’s computers are incredibly complex, they are built on simple logical structures like latches and registers — layers of abstraction stacked over time.
