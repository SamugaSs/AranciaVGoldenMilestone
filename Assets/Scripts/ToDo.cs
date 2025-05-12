/*****************************************************************************
// File Name : ToDo.cs
// Author : Gabriel Flores-Martinez
// Creation Date : March 31, 2025
//
// Brief Description : This script is used to spawn enemies for combat
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDo
{
    /* This script is here for the sole purpose of having somewhre besides Onenote or Notes on my phone to track stuff. Kind of like a log I guess?
     * 
     * 
     * This list has not been updated in awhile. To be updated in a few days
     *  -- This list was in fact, not update later
     * 
     * 
     * 
     * Need to change all deaths and similar stuff that restart the scene when dying to instead respawn player at coordinates(have coordinates being a serialized field Vector3 so that I 
     * can cuztomize it in Unity for each different trigger).
     * 
     * Still need to make char, hunter like.So what if, I make the spindash and an in air dash ability that when dashing through enemies, it kills them. Probs have it so enemy colliders are triggers and when triggered,
     * they check if the player are in a dash or spindash state. If they are, then the enemy is killed. If not, player takes damage.
     * 
     * --Health is implemented though able to be changed. Just need to set up checkpoints to be able to implement "infinit lives"
     * Infinite lives, only thing is that dying sets you back far-ish. Depends on where triggers are set on map that act as checkpoints
     * 
     * Powerup Ideas;
     * -- Invincibility?
     * -- Restore Health
     * --
     *
     * Add a ramp that gives the player a big boost(similar to dash/spindash)
     * --Or just some kind of speedboosting thing(maybe that can be a powerup instead???)
     * 
     * Score, what should the "coins" be? Gems? Food? 
     * 
     * Camera still is finnicky, unsure if just an editor problem. Make a build of this and test it
     * 
     * In-Game pause menu. Include sound settings here.
     * ---Update: Everything but the options are implemented. Though I wont look to implement until i actually look to put sounds and such in
     * 
     * ! Cinemachine Implemented
     * --Changes do need to be made to it
     * 
     * ! Implemented teleporter that changes player locations
     * --Though I may need to make some changes regarding this and/or cinemachine so going through them isnt so jarring(make is Look seamless)
     * 
     * ! Implemented dashing in air and spindash on ground(though I should look to tweak further with spindash)
     * 
     * ! Changed movement, will likely still with this
     * 
     * 
     * Credits that have to be given at end of game for assets:
     *  - Creator of the gems that I use for coins
     *  - Medieval town
     *  - If used, low poly fruits
     *  - Low poly foods(used the cheese)
     *  - Foliage
     *  -Low Poly Market
     *  -Low Poly environment starter pack
     *  -Mine
     *  - Food Monsters character and animation pack
     *  - Simple Gems and Items Ultimate Animated Customizable Pack
     *  - Free Sound Effects Pack(Olivier)
     *  
     */
}
