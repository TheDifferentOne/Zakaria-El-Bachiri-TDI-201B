//* HTML elements
const   apiURL  = 'http://localhost:8070/api/foods'
        nav = document.querySelector('nav'),
        showMeBtn = document.getElementById('showMeBtn'),
        deatilsBtn = document.getElementById('detailsBtn'),
        countries = document.getElementById('leftSide'),
        firstLiChild = document.querySelector('#leftSide ul li:first-child'),
        otherFood = document.querySelectorAll('.otherFood'),
        ingredients = document.querySelector('#ingredients ul'),
        directions = document.querySelector('#Directions ul');

let selectedCountryName ;

//* Hide or show food details
function hideOrShow(style){
    //Todo Show elements in the UI
    document.getElementById('ingredients').style.display = style;
    document.getElementById('Directions').style.display = style;

}
        
//* Load data at the beginning
document.addEventListener('DOMContentLoaded', () => {
     //! Hide food deatils in the UI
     hideOrShow('none');

    //! Coloring backgrund
    firstLiChild.className='selectedCountry';
    selectedCountryName = firstLiChild.textContent;
    //! Display data is th UI
    (async function GetData(){
        let foods=[]; 
        await getIngredients(apiURL)
        .then(data => {
            for (let i = 0; i < data.length; i++) {
                if (data[i].country === firstLiChild.textContent) {
                    foods.push(data[i]);
                }else continue;
            }  
        });
        display('#middle', foods[0])
        display('.firstFood',foods[1]) 
        display('.secondFood',foods[2]) 
    })()
})

//* Scroll event for nav bar
document.addEventListener('scroll',() => {
    if (scrollY  > 40) {
        nav.style.backgroundColor='rgba(245, 71, 72,0.9)' 
    }else{
        nav.style.backgroundColor='transparent' 
    }
});

//* Show me click event
showMeBtn.addEventListener('click',() => {
    const positionYOfH2 = document.querySelector('section > h2').offsetTop;
    window.scroll({
        top:positionYOfH2 - 60,
        behavior:"smooth"
    })
})

//* Countries click event
countries.addEventListener('click', (e) => {
    let selectedItem;

    //!Get the clicked li 
    if (e.target.tagName === 'SPAN' || e.target.tagName === 'IMG') {
        selectedItem = e.target.parentElement;
    } else if (e.target.tagName === 'LI'){
        selectedItem = e.target;
    }else return;

    //!Change the background-color
    if(selectedItem.className === 'selectedCountry'){
        return;
    }else{
        // remove background-color from other siblings
        removeBgColorForOtherSiblings(selectedItem);
        
        // Set background fot clicked li
        selectedItem.className='selectedCountry';
        
        // Get the name of selected country
        selectedCountryName = selectedItem.textContent;
        
        // Display data is th UI
        (async function GetData(){
            let foods=[]; 
            await getIngredients(apiURL)
            .then(data => {
                for (let i = 0; i < data.length; i++) {
                    if (data[i].country === selectedCountryName) {
                        foods.push(data[i]);
                    }else continue;
                }  
            });
            display('#middle', foods[0])
            display('.firstFood',foods[1]) 
            display('.secondFood',foods[2]) 
        })()
    }
    
})

//* Display info in a specified selector
function display(selector,food){
    //Food name
    document.querySelector(`${selector}  h2`).textContent = food.name;
    //Cooking time
    //! split into hours and minutes
    const cookingTime = Number(food.cookingTime);
    if (cookingTime < 60)
        document.querySelector(`${selector} .foodInfo h4`).textContent = `${food.cookingTime} m`;
    else{
        const hours = Math.floor(cookingTime/60);
        const minutes = Math.floor((((cookingTime/60) % 1)) * 60);

        if (Number.isInteger(cookingTime/60))
            document.querySelector(`${selector} .foodInfo h4`).textContent = `${hours}h`;
        else    
            document.querySelector(`${selector} .foodInfo h4`).textContent = `${hours}h ${minutes}m`;
    }
        
    //Servings 
    const icons = document.querySelector(`${selector} .foodInfo > div > div`);
    icons.innerHTML = '';
    if (parseInt(food.servings) > 20){
        let icon = document.createElement('i');
        icon.className = 'fas fa-user fa-sm';
        icons.appendChild(icon) ;
        icons.appendChild(document.createTextNode(` * ${food.servings}`))
    }else{
        for (let i = 0; i < food.servings; i++) {
            let icon = document.createElement('i');
            icon.className = 'fas fa-user fa-sm';
            icons.appendChild(icon);
        }
    }

    //Food picture
    (async function getData(){
        //!Get the first pic 
        let pic;
        await getIngredients(`${apiURL}/${food.name}`)
        .then(data => {pic = data.foodPics[0].pic1;});
        
        //!Convert bytes to a real picture
        // style="background-image: url(data:image/png;base64,${e.Image});"
        imgDOM = document.querySelector(`${selector} > .img`);
        imgDOM.style.background = `url(data:image/png;base64,${pic}) no-repeat center center/cover`
    })()
}

//* Right side click event
//#region right side
otherFood.forEach(div => {
    div.addEventListener('click',(e) => {
        //!Hide food details
        hideOrShow('none'); 

        //! Get className
        className = e.currentTarget.classList[1];

        //! Get clicked food name
        clickedFoodName = e.currentTarget.querySelector('h2').textContent;

        //! Get the main food name
        mainFoodName = document.querySelector('#middle h2').textContent;

        //! Change positions
        // Display data is th UI
        (async function GetData(){
            let foods=[]; 
            await getIngredients(apiURL)
            .then(data => {
                for (let i = 0; i < data.length; i++) {
                    if (data[i].country === selectedCountryName) {
                        foods.push(data[i]);
                    }else continue;
                }  
            });
            
            const clickedFood = foods.find(food => food.name === clickedFoodName);
            const mainFood = foods.find(food => food.name === mainFoodName);

            display('#middle',clickedFood)
            display(className === 'firstFood' ? '.firstFood' : '.secondFood',mainFood) 
        })()
    });
})
//#endregion

//* Remove bg color for other siblings
function removeBgColorForOtherSiblings(selectedItem){
    ulChildren = Array.from(countries.children[0].children);
    ulChildren.forEach(li => {
        if (!li.isEqualNode(selectedItem)) 
            li.classList.remove('selectedCountry');
    });
}

//* Details button click event
deatilsBtn.addEventListener('click', (e) => {
    getIngredients('http://localhost:8070/api/foods')
    .then(data => {
        //! Get the food name  
        const foodName = e.target.parentElement.previousElementSibling.previousElementSibling.textContent;
        // console.log(foodName);
        //! Get data of this food
        (async function getData(){
            //?Get ingredients 
            await getIngredients(`${apiURL}/${foodName}`)
            .then(data => {
                
                //TODO Ingredients list 
                ingredients.innerHTML = '';
                for (let i = 0; i < data.recipes.length; i++) {
                    let li = document.createElement('li');
                    li.appendChild(document.createTextNode(`${data.recipes[i].quantity} ${data.recipes[i].name}`))
                    ingredients.appendChild(li);
                }
                
                //TODO Directions List 
                directions.innerHTML='';
                for (let i = 0; i < data.directions.length; i++) {
                    let div = document.createElement('div');
                    div.className='directionInfo';
                    let img = document.createElement('img');
                    let h = document.createElement('h3');
                    img.src = 'img/forkAndSpoon.png';
                    h.textContent = `Setup ${i+1}`;
                    h.className = 'setup';
                    div.append(img, h)

                    let li = document.createElement('li');
                    li.appendChild(div);
                    li.appendChild(document.createTextNode(`${data.directions[i].directions}`))
                    directions.append(li,document.createElement('br'));
                }
            
                //Todo Show elements in the UI
                hideOrShow('block');
            });

        })()
    });
})

//* Fetch api function 
async function getIngredients (url){
    const response = await fetch(url);
    const data = await response.json();
    return data
} 

