var count = 60;
setInterval(function () { if (count < 0) { location.reload(); } console.log(count); count--; }, 1000);

