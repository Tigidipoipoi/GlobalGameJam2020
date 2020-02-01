using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameFlow : MonoBehaviour
{
    public static event Action<GameState> StateStarted;

    public static event Action<GameState> StateEnded;

    public Hero Hero;

    public Player Player;

    public List<GameState> History;

    public GameState CurrentState;

    public List<GameState> AllStates;

    public int CurrentLevel = 0;

    bool m_WasCurrentStateApplied;

    public const int NB_ELEMENTS = 5;

    public const float ELEMENT_BUFF = 2.0f;

    public void Update()
    {
        if (CurrentState == null)
        {
            return;
        }

        CurrentState.Update();

        //Try applying state.
        if (!m_WasCurrentStateApplied)
        {
            if (!CurrentState.CanApply())
            {
                return;
            }

            CurrentState.Apply();
            m_WasCurrentStateApplied = true;
        }

        //Try transitioning.
        if (CurrentState.IsDone())
        {
            GoToNextState();
        }
    }

    void GoToNextState()
    {
        GameState nextState = null;

        switch (CurrentState)
        {
            case FightState _:
            {
                if (Hero.CurrentHealth <= 0)
                {
                    nextState = AllStates.Find(state => state is VictoryState);
                }
                else
                {
                    nextState = AllStates.Find(state => state is RecoveryState);
                }

                Assert.IsNotNull(nextState);

                break;
            }

            case RecoveryState _:
            {
                nextState = AllStates.Find(state => state is TestimonyState);
                Assert.IsNotNull(nextState);

                break;
            }

            case TestimonyState _:
            {
                nextState = AllStates.Find(state => state is LootState);
                Assert.IsNotNull(nextState);

                break;
            }

            case LootState _:
            {
                nextState = AllStates.Find(state => state is PotCreationState);
                Assert.IsNotNull(nextState);

                break;
            }

            case PotCreationState _:
            {
                nextState = AllStates.Find(state => state is PotCreationState);
                Assert.IsNotNull(nextState);

                break;
            }

            case VictoryState _:
            {
                //TBD

                break;
            }
        }

        SwitchTo(nextState);
    }

    void SwitchTo(GameState next)
    {
        if (CurrentState != null)
        {
            //Clean state
            CurrentState.Exit();

            CurrentState.Flow = null;
            History.Add(CurrentState);

            //Raise event
            StateStarted?.Invoke(CurrentState);
        }

        CurrentState = next;

        // Reset meta data.
        m_WasCurrentStateApplied = false;

        if (CurrentState != null)
        {
            //Setup state
            CurrentState.Enter();

            CurrentState.Flow = this;

            //Level up as soon as you get a villager complaint/testimony
            if (CurrentState is TestimonyState)
            {
                ++CurrentLevel;
            }

            //Raise event
            StateEnded?.Invoke(CurrentState);
        }
    }

    public void Reset()
    {
        History.Clear();

        CurrentLevel = 0;

        CurrentState = null;

        m_WasCurrentStateApplied = false;
    }
}
