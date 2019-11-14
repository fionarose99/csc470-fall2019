# "Wheelie" - Final Project Design Document
*11/14/19*

## Gameplay and Thematic Description
In *Wheelie*, the player will navigate a series of obstacles in a manual wheelchair. Players will be encouraged to pursue power-ups--via speed-running levels and collecting coin-like objects--which will help them avoid these obstacles. Obstacles will be able to be avoided by steering and jumping, and jumping will be animated to look like the player is doing a wheelie and then hopping slightly in their wheelchair. Hitting obstacles will cause the player to lose lives; once they run out of lives, it's Game Over. The point of the game is to draw attention to obstacles wheelchair users face that able-bodied players may not often think about.

Power-ups, including extra lives, will be obtainable in a shop section which allows players to trade coins for power-ups. (Lives will also replenish at the start of each new level.) At the end of each level, a game timer will convert the player's time remaining into bonus coins. These coins will be added to the coins the player picked up during the level and they will then have the option to spend coins on power-ups. A high score consisting of coins accumulated--through both time remaining and coins collected--will also be saved for each level.

## Visual Style
The game will take after games like *F-Zero* and *Mario Kart* in its camera techniques, following the player-wheelchair avatar from behind and above them in a third-person POV. Each level will take place on a simple track with side-bumpers and three lanes; though marked on the track, the player will be able to move across and between lanes freely. Lanes will serve, then, as guides for where to place obstacles and will be textured also for stylistic purposes. Otherwise, the visuals will adhere mostly to a clean, voxel-like style reminiscent of games like [*Crossy Road*](https://www.youtube.com/watch?v=siHkMYNMBkM), [*Riverbond*](https://cococucumber.co/home/riverbond/), and [*Stellar Overlord*](https://www.ign.com/videos/2017/03/29/stellar-overload-trailer).

## Audio Style
For music, *Wheelie* will pay homage to games like *F-Zero* and *Excitebike* with a few simple racing tracks composed on a chiptune synthesizer. *Mario Kart 8* did this in a few DLC levels that paid homage to [*Excitebike*](https://www.youtube.com/watch?v=rGQGJFnZEik) and [*F-Zero*](https://youtu.be/obr-T3e_wY8); I hope to follow in their example (especially in the case of the *Excitebike* cover). And, on its final level--which will be a bit darker in tone--the backing track will take inspiration from the Hotland section of the *Undertale* soundtrack (such as [*Another Medium*](https://www.youtube.com/watch?v=xLsuam9o9BA)).

Sound effects will consist of things like a "vroom" or spokes-clattering sound for player movement, a coin or ding sound when picking up a coin, a mouse-click-like sound which plays when a power-up is bought, a buzzer sound when players try to purchase power-ups they can't afford, 3-to-5-second songs for winning and losing levels, and a cymbal crash that plays when the player collides with an obstacle. (The cymbal crash is intended to play off the terrifying reality of what happens when a wheelchair hits an obstacle for comedic effect, thus maintaining the game's light-hearted tone.) 

## Technical Specifications
### Low-Bar
* GUI Designs/Interface Sketches
* Start menu, start button
* 3rd-person-behind, unangled POV
* Basic player avatar
* Player movement (with character controller)
* One course with one kind of obstacle, coins (with sound effects), music
* Lives counter (GUI)
* Coins counter (GUI)
* One kind of obstacle (with collisions that decrement lives counter)
* Game Over Screen

### Target
* Start menu, start button, **player name entry**
* 3rd-person-behind, unangled, **camera-follow-player** POV
* Basic player avatar **that looks like a wheelchair**
* Player movement (with character controller)
* **Two** courses with one kind of obstacle, coins (with sound effects), same music track
* Lives counter (GUI)
* Coins counter (GUI)
* **High-score counter** based on coins collected
* Shop (GUI) with one power-up (extra life)
* Game Over Screen (with **sound effects**)

### High-Bar
* Start menu, start button, player name entry, **music**
* 3rd-person-behind, **slightly angled**, camera-follow-player POV
* **Nice-looking** wheelchair avatar
* Player movement (with character controller, **movement sound effects**)
* **Two** kinds of obstacles (with collisions that decrement lives counter, **sound effects**, **collision animation**)
* **Three** courses with **two** kinds of obstacles, coins (with sound effects, **animation**), **two** music tracks (one for lvls. 1-2, one for lvl. 3)
* Lives counter (GUI)
* Coins counter (GUI)
* Shop (GUI) with **two** power-ups (extra life, **temporary invincibility**), **animation**, **sound effects**
* Level timer (GUI)
* High-score counter based on **time-remaining-to-coins** conversion + coins collected, **attached to player name entry**
* Game Over Screen (with sound effects)

## Timeline
* Class 11/18: Player movement (with collision detectors set up), basic camera setup, one course, obstacle prefabs, coin prefabs, GUI Designs/Interface Sketches. **1/2 of Low Bar**
* Class 11/21: Coin-player and obstacle-player collisions resulting in changes to lives counter and coin counter, start screen, Game Over screen **Mostly finished with Low Bar**
* Class 11/25: Sound effects, music, start screen, game over screen. **Low Bar finished and refined**
* Class 12/5: Camera follow player, add a course, high score counter, game over screen with sound effects, lay out shop GUI, wheelchair avatar. **3/4 of additions for Target**
* Class (or office hours) 12/9: Finish shop, refine. **Finish Target**
* On or before 12/10: Add as much of High-Bar as possible, build to WebGL (and troubleshoot). **Some of High Bar, polishes**
* On or before 12/11: Write one-pager, take screenshots for website, seek advice on website setup, take footage for trailer **Finalizing**
* Shoot simple trailer, finalize simple website **Turn in**

***
### Proposal v.1
*11/11/19*

#### Game Idea #1: "Wheelie"
> In *Wheelie*, the player would navigate a series of obstacles in a manual wheelchair. Most of the game would take place on a ~3 lane course in the style of early games in the *F-Zero* franchise. Games in the legacies of *Mario Kart*, certain 3D *Sonic* titles, and *Crash Bandicoot* are also comparable. But, time permitting, different levels could emulate different styles of historic games, including side-scrolling (visa vie *Mario Bros*).

> The player's primary objective in this game would be to pursue power-ups, via navigation towards them or earning them with in-game points (racked up by course completion time, remaining lives at the end of courses, coin-item collection, and etc. incentive factors), that would allow them to surpass various obstacles. For example, wheelchairs have this problem most able-bodied folks don't usually think about (in my experience) where when their casters hit uneven terrain, they can flip forwards end over end, injuring the user (sometimes severely). A power-up that prevents this flipping would be like an invincibility star. Better (larger) casters could provide an extra life. Special goggles could reveal/highlight obstacles for the player for a limited time. And, etc. Obstacles could be various, from other vehicles obstructing part of the course (which the player would have to dodge as they approach at high speeds) to pot-holes the player would essentially have to jump--or do a "wheelie" to avoid.

> This game's purpose, beyond its inherent worth as a fun racing/platforming hybrid, would be to draw attention to some obstacles wheelchair and other assistive device users face on a regular basis. Ideally, it would cause able-bodied players to stop and think about these obstacles when they might not have otherwise. This will go a little ways, I'd hope, towards building awareness and community, and even if that's for just a few more people--a few more connections--that would be a good thing. :)

#### Game Idea #2: "How to Succeed"
> *How to Succeed* would be an extension of our game03 assignment for which I worked on a mailroom simulator/sorting game based on the musical I was in this fall. However, in this version, that mailroom sorting mini-game would be but one level and the overall game would be turned into a dungeon-crawler/RPG. Things like the ally-bars, gaining clues that would help the player advance in the World Wide Wicket Company faster, and the player having to hide their gender would stay and be expanded on, building out the original concept I introduced in *Mailroomery* (game03).