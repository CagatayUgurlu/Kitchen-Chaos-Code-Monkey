using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Cache;
using UnityEngine;
using UnityEngine.UIElements;

public class DeliveryManager : MonoBehaviour
{

    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    public event EventHandler OnRecipeSuccess;
    public event EventHandler OnrecipeFailed;

    public static DeliveryManager Instance { get; private set; }


    [SerializeField] private RecipeListSO recipeListSO;


    private List<RecipeSO> waitingRecipeSOList;

    private float spawnRecipeTimer;
    private float spawnRecipeTimerMax = 7f;
    private int waitingRecipesMax = 3;
    private int successfullRecipesAmount;

    private void Awake()
    {
        Instance = this;


        waitingRecipeSOList = new List<RecipeSO>();
    }

    private void Update()
    {
        spawnRecipeTimer -= Time.deltaTime;
        if (spawnRecipeTimer <= 0f)
        {
            spawnRecipeTimer = spawnRecipeTimerMax;

            if (KitchenGameManager.Instance.IsGamePlaying() && waitingRecipeSOList.Count < waitingRecipesMax)
            {
                RecipeSO waitingRecipeSO = recipeListSO.recipeSOList[UnityEngine.Random.Range(0, recipeListSO.recipeSOList.Count)];

                waitingRecipeSOList.Add(waitingRecipeSO);

                OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
    {
        for (int i = 0; i < waitingRecipeSOList.Count; i++)
        {
            RecipeSO waitingRecipeSO = waitingRecipeSOList[i];

            if (waitingRecipeSO.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count)
            {
                //Has the same number of ingredients
                bool plateContentsMatchesRecipe = true;
                foreach(KitchenObjectSO recipeKitchenObjectSO in waitingRecipeSO.kitchenObjectSOList)
                {
                    // Cycling through all ingredients in the recipe
                    bool ingredientFound = false;
                    foreach (KitchenObjectSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList())
                    {
                        //Cycling through all ingredients in the plate
                        if (plateKitchenObjectSO == recipeKitchenObjectSO)
                        {
                            // Ingredient matches
                            ingredientFound = true;
                            break;
                        }
                    }
                    if (!ingredientFound)
                    {
                        // This recipe ingredient was not found on the Plate
                        plateContentsMatchesRecipe = false;
                    }
                }
                if(plateContentsMatchesRecipe)
                {
                    // Player delivered the correct recipe!
                    successfullRecipesAmount++;
                    waitingRecipeSOList.RemoveAt(i);

                    OnRecipeCompleted?.Invoke(this,EventArgs.Empty);
                    OnRecipeSuccess?.Invoke(this,EventArgs.Empty);
                    return;
                }
            }
        }
        // No Matches Found!
        // Player did not deliver a correct recipe.
        OnrecipeFailed?.Invoke(this,EventArgs.Empty);
    }
    
    public List<RecipeSO> GetWaitingRecipeSOList()
    {
        return waitingRecipeSOList;
    }

    public int GetSuccessfullRecipesAmount()
    {
        return successfullRecipesAmount;
    }
}
