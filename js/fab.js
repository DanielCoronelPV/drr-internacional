window.setupFab = () => {
    const mainFab = document.getElementById('mainFab');
    const fabContainer = document.getElementById('fabContainer');
    const mainBubble = document.getElementById('mainBubble');
    const icon = mainFab.querySelector('i');
    let isOpen = false;

    if (!mainFab || !fabContainer) return;

    mainFab.addEventListener('click', () => {
        isOpen = !isOpen;
        fabContainer.classList.toggle('open', isOpen);
        icon.className = isOpen ? 'fas fa-times' : 'fas fa-comments';

        if (mainBubble) {
            mainBubble.style.display = isOpen ? 'none' : 'block';
        }
    });
};