window.clientsSlider = {
    scroll(container, delta) {
        const totalWidth = container.scrollWidth;
        const visibleWidth = container.clientWidth;
        const currentScroll = container.scrollLeft;
        const newScroll = currentScroll + delta;

        // Loop infinito
        if (newScroll >= totalWidth - visibleWidth) {
            container.scrollLeft = 0;
        } else if (newScroll < 0) {
            container.scrollLeft = totalWidth - visibleWidth;
        } else {
            container.scrollLeft = newScroll;
        }
    },

    initDrag(container) {
        let isDown = false;
        let startX;
        let scrollLeft;

        container.addEventListener('mousedown', (e) => {
            isDown = true;
            container.classList.add('dragging');
            startX = e.pageX - container.offsetLeft;
            scrollLeft = container.scrollLeft;
        });

        container.addEventListener('mouseleave', () => {
            isDown = false;
            container.classList.remove('dragging');
        });

        container.addEventListener('mouseup', () => {
            isDown = false;
            container.classList.remove('dragging');
        });

        container.addEventListener('mousemove', (e) => {
            if (!isDown) return;
            e.preventDefault();
            const x = e.pageX - container.offsetLeft;
            const walk = (x - startX) * 1.5;
            container.scrollLeft = scrollLeft - walk;
        });
    }
};
