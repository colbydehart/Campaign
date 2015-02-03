#CAMPAIGN USER STORIES 

---

*  Create
    *  As a **GM** I want to **Make a new campaign**.
    *  As a **GM** I want to **Add a new orphan panel (Adventure)**
    *  As a **GM** I want to **Add a new child panel (Encounter)**.
*  Read
    *  As a **GM** I want to **View my campaigns**.
    *  As a **GM** I want to **View a campaign's adventures**.
    *  As a **GM** I want to **Search for an adventure in a campaign**.
    *  As a **GM** I want to **Search for an encounter in an adventure**.
    *  As a **GM** I want to **View a panel**.
*  Update
    *  As a **GM** I want to **Edit a panel**.
    *  As a **GM** I want t **Make a previous panel a child of current panel**
    *  As a **GM** I want to **Edit a campaign's info**.
    *  As a **GM** I want to **Take notes on a panel**.
*  Destroy
    *  As a **GM** I want to **Remove a child panel**.
    *  As a **GM** I want to **Remove an adventure**.
    *  As a **GM** I want to **Remove a campaign**.

---

##As a GM I want to make a new campaign.
- Done from home window listing all campaigns, at the bottom.
- User mus supply name for the new campaign.
- Upon creation, user will be taken to the show page for their new campaign.

---

##As a GM I want to add a new orphan panel (Adventure)
-  Done from The campaign show screen that shows all adventures for a camaign
-  Must supply a name for the new adventure.
-  Upon creation, user will be taken to the edit page for their new adventure.

---

##As a GM i want to add a new child panel (Encounter).
-  Done from the edit page for a panel, accessed via search or child
   navigation.
-  At the bottom wil be a list of child panels and a button to add
   a new child.
-  User must supply a name for the new encounter.
-  After creation, user will navigate to the edit page for the new encounter.

---

##As a GM i want to view my campaigns

- This will be the main window
- If user is somewhere else, she can navigate back via breadcrumbs
- App will grab all the campaigns and display their names, links to their 
  show page and buttons to delete
- Also button at bottom to add campaign

---

##As a GM i want to view a campaign's adventures

- Click on the campaign from the main view of campaigns.
- Will list all adventures, their experience rewarded, link to show, and delete button
- Also button at bottom to add campaign

---

##As a GM i want to search for an adventure in a campaign

- Search bar in top right of campaign show page.
- Typing in a search query will bring up a list of search results, or "no results found"
- Clicking on a result will go to that panel's page

---

##As a GM i want to search for an encounter in an adventure

- Search bar in top right of panels in an adventure.
- Typing in a search query will bring up a list of search results, or "no results found"
- Clicking on a result will go to that panel's page.

---

##As a GM i want to view a panel

- Clicking on an adventure in a campaign will go to the root panel of that adventure. (can also get here by searching or navigation)
- The window will contain breadcrumb navigation in top left and a search in current adventure textbox in top right
- Above the content area will be a list of parents that the panel has.
- A header will say the name of the panel with the content below it.
- Below this will be a list of all the children that this panel has.

---

##As a GM i want to edit a panel

- On the panel show page, there will be an edit button that will navigate to an edit page.
- The page will look as same as the show page, but the title and content will now be a text input and textarea so that the user can edit. There will also be a box to put in encounter's experience. 
- The links to parents and childen will now be links to their edit pages and there will be  button to ad a new child.
- There will be a save button below the textarea that must be clicked to save the panel. 
- The edit button will be replaced with a show button.

---

##As a GM i want to make a previous panel a child of current panel
- If user types an '@' when making a new panel, a list of previously made panels in thes same adventure will come up. 
- If the user clicks on one of these, thes relationship will be made and they will be taken to the edit page for the clicked panel

---

##As a GM i want to Edit a campaign's info

- On the campaign's page next to the title, there will be an edit button.
- If the user clicks the button, a prompt will come up and the user can change the name of the campaign.

---

##As a GM i want to take notes while on a panel
- On the right side of the panel show page will be a button to show notes for current adventure.
- This will persist throughout navigation and save on exiting an adventure.
- the notes will be an editable textarea.
- clicking the button again will hide the notes area.

---

##As a GM i want to remove a child panel
- On the edit page for a panel will be a list of chidren at the bottom.
- When hovering over a child button, an &times; button will show and the user can click this to delete it.
- A prompt will come up to make sure the user deletes it.
- The child will be deleted as well as any orphaned children.

---

##As a GM i want to remove an adventure

- There will be a button on the listing of all adventures on a campaign's show page.
- The user will be prompted on clicking for conirmation to delete.  

---

##As a GM i want to remove a campaign
- There will be a button on the listing of campaigns on the main page to delete a campaign
- The user will be prompted on clicking for conirmation to delete.  