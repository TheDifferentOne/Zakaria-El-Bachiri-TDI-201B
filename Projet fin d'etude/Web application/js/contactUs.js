//* Html objects
const animationDiv = document.getElementById("animations");
const firstName = document.getElementById("firstNameTxtBx");
const lastName = document.getElementById("lastNameTxtBx");
const email = document.getElementById("emailTxtBx");
const phone = document.getElementById("phoneTxtBx");
const fullNameSpan = document.getElementById("fullName");
const thanksMessage = document.getElementById("thanksMessage");

const sendBtn = document.getElementById("sendBtn");

//* Regular expressions 
const firstNameTxtRegEx = /^[a-z]{4,}$/i;
const lastNameTxtRegEx = /^[a-z]{1,}\s?[a-z]{2,}$/i;
const emailRegEx = /^[a-z][a-z0-9\-_.]{2,}@[a-z0-9]{4,}\.[a-z]{2,}$/i;
const phoneRegEx = /^(0|212|\+212)[6-7][0-9]{8}$/i;

//!Hiding Thanks message at the beginning
thanksMessage.style.display="none";

//Set focus on firstName field
firstName.focus();

//* Send button click event 
sendBtn.addEventListener('click',(e)=>{
    const invalidFields = document.querySelectorAll(":invalid");

    if (invalidFields.length > 0){
        e.preventDefault();    
        return;
    }
    else{
        fullNameSpan.textContent = `${firstName.value} ${lastName.value}`
        thanksMessage.style.display="block";
    }

});

//* Handling inputs
// First name blur event
firstName.addEventListener('blur',()=>{
    createErroMessage(firstName,firstNameTxtRegEx,'*4 or more characters❌');        
});

// Last name blur event
lastName.addEventListener('blur',()=>{
    createErroMessage(lastName,lastNameTxtRegEx,'*Invalid inputs❌');        
});

// Email blur event
email.addEventListener('blur',()=>{
    createErroMessage(email,emailRegEx,'*Invalid email adress❌');        
});

// Phone blur event
phone.addEventListener('blur',()=>{
    createErroMessage(phone,phoneRegEx,'*Invalid phone number❌');        
});

function createErroMessage(inputField,regEx,message){
    if(!regEx.test(inputField.value)){
        if(inputField.nextElementSibling.className !=='error')  {
            let errorDiv = document.createElement('div');
            errorDiv.appendChild(document.createTextNode(message));
            errorDiv.className='error';
            inputField.insertAdjacentElement("afterend",errorDiv);
        }
    }else{
        if(inputField.nextElementSibling.className ==='error')
            inputField.nextElementSibling.remove();
    }
}


 
