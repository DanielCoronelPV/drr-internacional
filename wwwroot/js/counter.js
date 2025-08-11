window.startCounters = function () {
    const counters = document.querySelectorAll(".counter");
    const options = { threshold: 0.5 };

    const startCounting = (entry) => {
        const el = entry.target;
        const target = +el.getAttribute("data-target");
        let current = 0;
        const increment = target / 100;
        const speed = 20;

        const updateCounter = () => {
            if (current < target) {
                current += increment;
                el.innerText = Math.ceil(current);
                setTimeout(updateCounter, speed);
            } else {
                el.innerText = target;
            }
        };

        updateCounter();
        observer.unobserve(el);
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                startCounting(entry);
            }
        });
    }, options);

    counters.forEach(counter => observer.observe(counter));
};