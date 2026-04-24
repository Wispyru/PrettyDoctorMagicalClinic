# 🖥️ Console Testing Commands

Quick reference for testing without the debug UI.

---

## Quick Copy-Paste Commands

### For Testing in Console

**Test Locked Buttons:**
```csharp
// Unlock all levels to test clicking them
PlayerPrefs.SetInt("UnlockedLevel", 999);
PlayerPrefs.Save();
Debug.Log("All levels unlocked");

// Lock all levels back
PlayerPrefs.SetInt("UnlockedLevel", 1);
PlayerPrefs.Save();
Debug.Log("Only Level 1 unlocked");
```

**Test Score Display (6.4):**
```csharp
// Test 0 Stars - No score
PlayerPrefs.DeleteKey("Score_Level1");
PlayerPrefs.Save();
Debug.Log("Cleared Level 1 score - click Level 1 button (expect ☆☆☆)");

// Test 1 Star - 30%
PlayerPrefs.SetInt("Score_Level1", 150);
PlayerPrefs.Save();
Debug.Log("Set Level 1 score to 150 (expect ★☆☆)");

// Test 2 Stars - 60%
PlayerPrefs.SetInt("Score_Level1", 300);
PlayerPrefs.Save();
Debug.Log("Set Level 1 score to 300 (expect ★★☆)");

// Test 3 Stars - 100%
PlayerPrefs.SetInt("Score_Level1", 650);
PlayerPrefs.Save();
Debug.Log("Set Level 1 score to 650 (expect ★★★)");
```

**Test Level 2:**
```csharp
// Unlock Level 2
PlayerPrefs.SetInt("UnlockedLevel", 2);
PlayerPrefs.Save();
Debug.Log("Level 2 unlocked");

// Set Level 2 score (assuming min=800)
PlayerPrefs.SetInt("Score_Level2", 900);
PlayerPrefs.Save();
Debug.Log("Set Level 2 score to 900 (expect ★★★)");
```

---

## Full Test Sequence

**Paste this entire sequence into Console:**

```csharp
// 1. RESET EVERYTHING
PlayerPrefs.DeleteAll();
PlayerPrefs.SetInt("UnlockedLevel", 1);
PlayerPrefs.Save();
Debug.Log("=== Test 1: Locked Buttons ===");
Debug.Log("Level 1 should be bright, Levels 2+ should be dimmed/locked");
Debug.Log("Try clicking Level 2 - should do nothing");

// Wait 5 seconds, then set score
Invoke(nameof(TestSequence2), 5f);

public void TestSequence2()
{
    Debug.Log("=== Test 2: Zero Stars ===");
    PlayerPrefs.DeleteKey("Score_Level1");
    PlayerPrefs.Save();
    Debug.Log("Click Level 1 - expect ☆☆☆ (all gray)");

    Invoke(nameof(TestSequence3), 5f);
}

public void TestSequence3()
{
    Debug.Log("=== Test 3: One Star (30%) ===");
    PlayerPrefs.SetInt("Score_Level1", 150);
    PlayerPrefs.Save();
    Debug.Log("Click Level 1 - expect ★☆☆ (1 yellow, 2 gray)");

    Invoke(nameof(TestSequence4), 5f);
}

public void TestSequence4()
{
    Debug.Log("=== Test 4: Two Stars (60%) ===");
    PlayerPrefs.SetInt("Score_Level1", 300);
    PlayerPrefs.Save();
    Debug.Log("Click Level 1 - expect ★★☆ (2 yellow, 1 gray)");

    Invoke(nameof(TestSequence5), 5f);
}

public void TestSequence5()
{
    Debug.Log("=== Test 5: Three Stars (100%) ===");
    PlayerPrefs.SetInt("Score_Level1", 650);
    PlayerPrefs.Save();
    Debug.Log("Click Level 1 - expect ★★★ (all yellow)");

    Invoke(nameof(TestSequence6), 5f);
}

public void TestSequence6()
{
    Debug.Log("=== Test 6: Unlock More Levels ===");
    PlayerPrefs.SetInt("UnlockedLevel", 3);
    PlayerPrefs.Save();
    Debug.Log("Levels 1-3 now unlocked. Set scores:");

    PlayerPrefs.SetInt("Score_Level2", 900);
    PlayerPrefs.SetInt("Score_Level3", 500);
    PlayerPrefs.Save();
    Debug.Log("Level 2: 900 (expect ★★★)");
    Debug.Log("Level 3: 500 (expect ★★★)");
    Debug.Log("All tests complete!");
}
```

---

## What To Look For

### Locked Button Test
```
✓ Level 1 is bright and clickable
✓ Level 2 is dimmed and NOT clickable
✓ Lock icon visible on Level 2
✓ Click Level 1 = Popup appears
✓ Click Level 2 = Nothing happens
```

### Score/Star Test (6.4)
```
Score 0:   ☆☆☆ (all gray)
Score 150: ★☆☆ (1 yellow, 2 gray)
Score 300: ★★☆ (2 yellow, 1 gray)
Score 650: ★★★ (all yellow)
```

---

## Interpretation

**Minimum Score = 500**

| Your Score | Calculation | Result | Stars |
|-----------|------------|--------|-------|
| 0 | 0/500 = 0% | Below 30% | ☆☆☆ |
| 150 | 150/500 = 30% | At 30% threshold | ★☆☆ |
| 300 | 300/500 = 60% | At 60% threshold | ★★☆ |
| 650 | 650/500 = 130% | Above 100% | ★★★ |

---

## Using With DebugLevelSystem

If you added DebugLevelSystem to your scene:

1. **Press 'D' during game** - Opens debug panel
2. **Click buttons** to set scores
3. **Watch results** as you click level buttons
4. **Press 'D' again** to close panel

This is faster than console commands!

---

## Manual Testing Without Debug

If you want to test without the debug script:

1. **In LevelMenu.cs**, temporarily add:
```csharp
private void Start()
{
    // Temporary testing
    PlayerPrefs.SetInt("UnlockedLevel", 999); // Unlock all
    PlayerPrefs.SetInt("Score_Level1", 650);  // Add score
    PlayerPrefs.SetInt("Score_Level2", 300);
    PlayerPrefs.Save();
}
```

2. **Test the popup**
3. **Remove the code** when done

---

## Verifying Results

### After Setting Score to 150 (1 star):
```
Console Output:
✓ Set Level1 score to 150
✓ UnlockedLevel: 1
✓ Level1 Score: 150

Click Level 1 Button:
✓ Popup appears
✓ "Best Score: 150" displays
✓ ★☆☆ shows (1 yellow star, 2 gray stars)
```

### After Setting Score to 650 (3 stars):
```
Console Output:
✓ Set Level1 score to 650
✓ UnlockedLevel: 1
✓ Level1 Score: 650

Click Level 1 Button:
✓ Popup appears
✓ "Best Score: 650" displays
✓ ★★★ shows (all 3 yellow stars)
```

---

## Keyboard Shortcut Method

**Add this to a quick test script:**

```csharp
private void Update()
{
    // Quick test keys
    if (Input.GetKeyDown(KeyCode.F1))
    {
        PlayerPrefs.SetInt("Score_Level1", 150);
        PlayerPrefs.Save();
        Debug.Log("F1: Set Level 1 to 150 (1★)");
    }

    if (Input.GetKeyDown(KeyCode.F2))
    {
        PlayerPrefs.SetInt("Score_Level1", 300);
        PlayerPrefs.Save();
        Debug.Log("F2: Set Level 1 to 300 (2★)");
    }

    if (Input.GetKeyDown(KeyCode.F3))
    {
        PlayerPrefs.SetInt("Score_Level1", 650);
        PlayerPrefs.Save();
        Debug.Log("F3: Set Level 1 to 650 (3★)");
    }

    if (Input.GetKeyDown(KeyCode.F4))
    {
        PlayerPrefs.DeleteKey("Score_Level1");
        PlayerPrefs.Save();
        Debug.Log("F4: Clear Level 1 score (0★)");
    }
}
```

Then just press F1-F4 to quickly switch between test scores!

---

## Recommended Test Flow

```
1. Start game
2. Press 'D' (or use console)
3. Click "Unlock All Levels"
4. Click Level 1 button → Should be bright
5. Click "Set Level 1 Score: 150"
6. Click Level 1 button → Check ★☆☆
7. Click "Set Level 1 Score: 300"
8. Click Level 1 button → Check ★★☆
9. Click "Set Level 1 Score: 650"
10. Click Level 1 button → Check ★★★
11. Click "Clear Level 1 Score"
12. Click Level 1 button → Check ☆☆☆
```

**Time: ~2-3 minutes for full test**

---

## Notes

- **Minimum scores** are in TemporaryLevelData array
- **Star thresholds** are fixed in StarRating.SetStars()
- **PlayerPrefs keys** must match exactly: "Score_Level1", "Score_Level2", etc.
- **Colors**: Yellow = filled, Gray = empty
