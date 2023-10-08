// Варіант 4. Розробити клас підсистеми для завантаження даних про онлайн зустріч (дата, опис, URL,
// список учасників) та списку всіх користувачів системи (ID, Ім'я, аватар) з файлів в форматі JSON та XML.
// Визначення типу файлу визначається при запуску системи. Передбачити, що дані про кожну зустріч та кожного
// користувача зберігаються в окремих файлах. Файл зустрічі містить імена файлів - учасників цієї зустрічі.

class MeetingLoader {
  constructor(file) {
    this.data;
    const extension = file.split(".").pop();

    if (extension === "json") {
      this.loadJson(file);
    } else if (extension === "xml") {
      this.loadXml(file);
    }
  }

  loadJson(file) {
    fetch(file)
      .then((response) => response.json())
      .then((data) => {
        this.data = data;
      });
  }

  loadXml(file) {
    fetch(file)
      .then((response) => response.text())
      .then((xml) => {
        const parser = new DOMParser();
        const xmlDoc = parser.parseFromString(xml, "text/xml");

        const date = xmlDoc.querySelector("date").textContent;
        const description = xmlDoc.querySelector("description").textContent;
        const url = xmlDoc.querySelector("url").textContent;

        const participants = [];
        const participantElements = xmlDoc.querySelectorAll("participant");
        participantElements.forEach((participantElement) => {
          participants.push(participantElement.textContent);
        });

        this.data = {
          date: date,
          description: description,
          url: url,
          participants: participants,
        };
      });
  }

  getMeetingData() {
    return this.data;
  }
}
