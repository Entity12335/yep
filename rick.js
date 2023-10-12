let rick = prompt("Cokolwiek?");
window.addEventListener("DOMContentLoaded", () => {
    if(rick == "rick") {
        document.querySelector("#p2").style.display = "block";
        document.querySelector("#p1").style.display = "none";
    }
})