const animationDiv = document.getElementById("animations");

//!Send animations div to background to allow user interatcion with the UI
setTimeout(()=>{ animationDiv.style.zIndex="-10"},2500)
