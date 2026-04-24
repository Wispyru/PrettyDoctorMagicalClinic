# 👀 Visual Guide - What You'll See

## When You Press 'D' - Debug Panel Appears

### Left Side of Screen:
```
┌─────────────────────────────────────────┐
│                                         │
│      === DEBUG CONSOLE ===              │
│      Press 'D' to toggle panel          │
│                                         │
│  [✓ Unlock All Levels        ]          │
│                                         │
│  [🔒 Lock All Levels          ]         │
│                                         │
│  [🔓 Unlock Level 2 Only      ]         │
│                                         │
│  --- SCORE TESTING (6.4) ---            │
│                                         │
│  [★☆☆ Level 1: 150 (1 star) ]          │
│                                         │
│  [★★☆ Level 1: 300 (2 stars)]          │
│                                         │
│  [★★★ Level 1: 650 (3 stars)]          │
│                                         │
│  [☆☆☆ Clear Level 1 (0 stars)]         │
│                                         │
│  [★★★ Level 2: 900 (3 stars)]          │
│                                         │
│  [🗑️ Clear All Scores         ]         │
│                                         │
│  --- CURRENT STATUS ---                 │
│  Unlocked Level: 1                      │
│  Level 1 Score: 0                       │
│  Level 2 Score: 0                       │
│                                         │
└─────────────────────────────────────────┘
```

### In Console (Ctrl + `):
```
After clicking "Set Level 1: 650 (3 stars)":

✓ Set Level1 score to 650

After clicking "Unlock All Levels":

✓ All levels unlocked!

Debug panel ON (press D to close)
```

---

## Before & After - Level Buttons

### BEFORE Clicking "Lock All Levels":
```
Level 1: ━━━━━━━━━━━ BRIGHT (clickable)
Level 2: ▒▒▒▒▒▒▒▒▒▒ DIMMED (locked) 🔒
Level 3: ▒▒▒▒▒▒▒▒▒▒ DIMMED (locked) 🔒
```

### AFTER Clicking "Unlock All Levels":
```
Level 1: ━━━━━━━━━━━ BRIGHT (clickable)
Level 2: ━━━━━━━━━━━ BRIGHT (clickable)
Level 3: ━━━━━━━━━━━ BRIGHT (clickable)
```

---

## Star Display Changes

### When Testing Scores:

#### Before Setting Score (Clear):
```
┌─────────────────────────────────────┐
│ Level 1                             │
│ ─────────────────────────────────── │
│ Cure 3 patients in the clinic       │
│                                     │
│ Best Score: 0                       │
│ Min Score: 500                      │
│                                     │
│ ☆☆☆  (All Gray - No stars)         │
│                                     │
│ [Proceed]           [Close]         │
└─────────────────────────────────────┘
```

#### After Setting Score to 150 (1 Star):
```
┌─────────────────────────────────────┐
│ Level 1                             │
│ ─────────────────────────────────── │
│ Cure 3 patients in the clinic       │
│                                     │
│ Best Score: 150                     │
│ Min Score: 500                      │
│                                     │
│ ★☆☆  (1 Yellow, 2 Gray)            │
│                                     │
│ [Proceed]           [Close]         │
└─────────────────────────────────────┘
```

#### After Setting Score to 300 (2 Stars):
```
┌─────────────────────────────────────┐
│ Level 1                             │
│ ─────────────────────────────────── │
│ Cure 3 patients in the clinic       │
│                                     │
│ Best Score: 300                     │
│ Min Score: 500                      │
│                                     │
│ ★★☆  (2 Yellow, 1 Gray)            │
│                                     │
│ [Proceed]           [Close]         │
└─────────────────────────────────────┘
```

#### After Setting Score to 650 (3 Stars):
```
┌─────────────────────────────────────┐
│ Level 1                             │
│ ─────────────────────────────────── │
│ Cure 3 patients in the clinic       │
│                                     │
│ Best Score: 650                     │
│ Min Score: 500                      │
│                                     │
│ ★★★  (All Yellow - Perfect!)        │
│                                     │
│ [Proceed]           [Close]         │
└─────────────────────────────────────┘
```

---

## Star Colors Closeup

### Empty Star (Gray):
```
    ☆
   /|\
  / | \
 |  |  |
```
**Color: Gray (0.5, 0.5, 0.5)**
**Meaning: Not earned**

### Filled Star (Yellow):
```
    ★
   /|\
  / | \
 |  |  |
```
**Color: Yellow/Gold (1, 1, 0)**
**Meaning: Earned**

---

## Test Sequence Visual

### Step 1: Click "Clear Level 1 (0 stars)"
```
Debug Panel                 Popup               Stars Show
[Click button] ───────────→ [Reopen] ───────────→ ☆☆☆
                                                (all gray)
```

### Step 2: Click "Set Level 1: 150 (1 star)"
```
Debug Panel                 Popup               Stars Show
[Click button] ───────────→ [Reopen] ───────────→ ★☆☆
                                                (1 yellow)
```

### Step 3: Click "Set Level 1: 300 (2 stars)"
```
Debug Panel                 Popup               Stars Show
[Click button] ───────────→ [Reopen] ───────────→ ★★☆
                                                (2 yellow)
```

### Step 4: Click "Set Level 1: 650 (3 stars)"
```
Debug Panel                 Popup               Stars Show
[Click button] ───────────→ [Reopen] ───────────→ ★★★
                                                (3 yellow)
```

---

## Level Button States

### Unlocked Level Button:
```
┌──────────────────┐
│                  │
│   LEVEL 1        │  ← Bright/Visible
│                  │  ← No lock icon
│  [Clickable ✓]   │  ← Can be clicked
│                  │
└──────────────────┘
```

### Locked Level Button:
```
┌──────────────────┐
│                  │
│   LEVEL 2        │  ← Dimmed/Grayed out
│                  │  ← Lock icon visible 🔒
│  [Not Clickable] │  ← Cannot be clicked
│                  │
└──────────────────┘
```

---

## Keyboard Visual

```
Your Keyboard:

Q W E R T Y U I O P
 A S D F G H J K L
  Z X C V B N M

Press this key (D):

Q W E [R] T Y U I O P
 A S [D] F G H J K L
  Z X C V B N M

When you press D:
Debug panel toggles on/off ↔ 
```

---

## Console Visual

### When Everything Works:
```
Console Output (press Ctrl + `)

Debug panel ON (press D to close)
✓ All levels unlocked!
✓ Set Level1 score to 150
✓ Set Level1 score to 300
✓ Set Level1 score to 650
✓ All scores cleared!
```

### When Something is Wrong:
```
Console Output (press Ctrl + `)

[Errors shown here]
ArgumentException: ...
NullReferenceException: ...
(Check here when things don't work)
```

---

## Full Game Layout

```
BEFORE:                          AFTER:
┌────────────────────────┐      ┌────────────────────────────┐
│      Level Menu        │      │ ┌─DEBUG─────┐ Level Menu  │
│                        │      │ │ CONSOLE   │              │
│ [LEVEL 1] [LEVEL 2]    │  →   │ │ [Button1] │ [L1] [L2]   │
│ [LEVEL 3] [LEVEL 4]    │      │ │ [Button2] │ [L3] [L4]   │
│                        │      │ │ [Status]  │              │
│                        │      │ └───────────┘              │
│                        │      │                            │
└────────────────────────┘      └────────────────────────────┘

Press 'D'                        Debug panel appears →
```

---

## Star Count Reference

When you see stars, here's what they mean:

| Stars | Meaning | Your Score |
|-------|---------|-----------|
| ☆☆☆ | Not played / 0% | 0 points |
| ★☆☆ | Getting there / 30% | 150 points |
| ★★☆ | Good progress / 60% | 300 points |
| ★★★ | Perfect score / 100%+ | 650+ points |

(Assuming minimum score is 500)

---

## Timeline

### T+0s: Start Playing
```
Game loads
```

### T+5s: Press D
```
Debug panel appears on left
```

### T+10s: Click "Clear Level 1"
```
Console shows: ✓ Cleared Level1 score
```

### T+15s: Click Level 1 Button
```
Popup appears with ☆☆☆
```

### T+20s: Click "Set Level 1: 150"
```
Console shows: ✓ Set Level1 score to 150
```

### T+25s: Close popup, click Level 1 again
```
Popup appears with ★☆☆
```

### T+30s: Repeat for 300 and 650 scores
```
Test 2 stars: ★★☆
Test 3 stars: ★★★
```

### T+45s: Test Complete!
```
All tests passed ✅
```

---

## Button Locations

### Debug Panel Buttons (Left Side):
```
Top 1/6: Unlock buttons
Middle 1/3: Score testing buttons
Bottom 1/6: Status display
```

### Level Buttons (Main Screen):
```
Top area: Brightly displayed (unlocked)
Levels 1-3: Dimmed (locked)
Icons: 🔒 on locked levels
```

### Popup Buttons (Center):
```
[Proceed] button: Bottom left
[Close] button: Bottom right
```

---

## What Should Change After Each Click

| Click This | This Changes |
|-----------|--------------|
| Unlock All | All buttons become bright |
| Lock All | Only Level 1 bright, rest dimmed |
| Set Score: 150 | Console shows message, no visual change yet |
| Click Level 1 | Popup appears with new score/stars |
| Clear Score | Score goes to 0, stars become gray |

---

## Expected vs Unexpected

### ✅ Expected (Good):
- D key opens debug panel
- Panel appears on left side
- Buttons are clickable
- Console shows messages
- Stars change color
- Scores display correctly
- Locked buttons don't open popup

### ❌ Unexpected (Bad):
- D key does nothing
- No panel appears
- Panel appears but buttons don't work
- No console messages
- Stars don't change
- Score shows wrong number
- Locked buttons open popup

---

## Color Reference

### Yellow/Gold Star (Earned):
```
RGB: (1, 1, 0)
Hex: #FFFF00
HLS: Bright
Effect: Bright yellow, very visible
```

### Gray Star (Not Earned):
```
RGB: (0.5, 0.5, 0.5)
Hex: #808080
HLS: Dim
Effect: Dark gray, less visible
```

---

You now know exactly what to expect! Press 'D' and test! 🎮
