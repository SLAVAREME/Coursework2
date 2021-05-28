let time = 70;
const TimerEl = document.getElementById("Timer");
const FormEl = document.getElementById("div_form");
var interval = setInterval(UpdateTimer, 1000);

function UpdateTimer()
{
    let seconds = time;
    seconds = seconds < 10 ? "0" + seconds : seconds;
    TimerEl.innerHTML = `${seconds}`;
    time--;
    if (time == -1)
    {
        FormEl.style = "display:block";
        clearInterval(interval);
    }
}